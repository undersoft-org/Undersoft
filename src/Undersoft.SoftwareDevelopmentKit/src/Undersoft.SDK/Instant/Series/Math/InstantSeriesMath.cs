namespace Undersoft.SDK.Instant.Series.Math;

using SDK.Series;
using Uniques;
using System.Linq;
using Rubrics;
using Set;
using Instant.Rubrics;

public class InstantSeriesMath : IInstantSeriesMath
{
    private MathRubrics rubrics;

    public InstantSeriesMath(IInstantSeries data)
    {
        rubrics = new MathRubrics(data);
        serialcode.Id = (long)DateTime.Now.ToBinary();
        if (data.Computations == null)
            data.Computations = new Catalog<IInstantSeriesMath>();
        data.Computations.Put(this);
    }

    public InstantSeriesMath(MathRubrics rubrics)
    {
        this.rubrics = rubrics;
        serialcode.Id = (long)DateTime.Now.ToBinary();
        if (rubrics.Data.Computations == null)
            rubrics.Data.Computations = new Catalog<IInstantSeriesMath>();
        rubrics.Data.Computations.Put(this);
    }

    public MathSet this[int id]
    {
        get { return GetMathSet(id); }
    }
    public MathSet this[string name]
    {
        get { return GetMathSet(name); }
    }
    public MathSet this[MemberRubric rubric]
    {
        get { return GetMathSet(rubric); }
    }

    public MathSet GetMathSet(int id)
    {
        MemberRubric rubric = rubrics.Rubrics[id];
        if (rubric != null)
        {
            MathRubric mathrubric = null;
            if (rubrics.MathsetRubrics.TryGet(rubric.Name, out mathrubric))
                return mathrubric.GetMathset();
            return rubrics.Put(rubric.Name, new MathRubric(rubrics, rubric)).Value.GetMathset();
        }
        return null;
    }

    public MathSet GetMathSet(string name)
    {
        MemberRubric rubric = null;
        if (rubrics.Rubrics.TryGet(name, out rubric))
        {
            MathRubric mathrubric = null;
            if (rubrics.MathsetRubrics.TryGet(name, out mathrubric))
                return mathrubric.GetMathset();
            return rubrics.Put(rubric.Name, new MathRubric(rubrics, rubric)).Value.GetMathset();
        }
        return null;
    }

    public MathSet GetMathSet(MemberRubric rubric)
    {
        return GetMathSet(rubric.Name);
    }

    public bool ContainsFirst(MemberRubric rubric)
    {
        return rubrics.First.Value.RubricName == rubric.Name;
    }

    public bool ContainsFirst(string rubricName)
    {
        return rubrics.First.Value.RubricName == rubricName;
    }

    public IInstantSeries Compute()
    {
        rubrics.Combine();
        rubrics
            .Where(p => !p.PartialMathset)
            .OrderBy(p => p.ComputeOrdinal)
            .Select(p => p.Compute())
            .ToArray();
        return rubrics.Data;
    }

    public IInstantSeries ComputeInParallel(int chunks = 4)
    {
        var rowcount = rubrics.Data.Count;
        var chunksize = rowcount / chunks;
        var lastchunksize = (rowcount - (chunksize * chunks)) + chunksize;
        InstantSeriesMath _temp = this;
        CompiledMathSet[][] mathChunks = new CompiledMathSet[chunks][];

        mathChunks.AsParallel().ForEach(
            (ism, x) =>
            {
                mathChunks[x] = _temp.Compile(x * chunksize, (x == chunks - 1) ? lastchunksize : chunksize);               
                _temp.Clone();
            }
        );

        mathChunks.AsParallel().ForEach((mch) => mch.ForEach((cms) => new Evaluator(cms.Compute)()));
        return rubrics.Data;
    }

    public CompiledMathSet[] Compile(int offset, int chunk)
    {
        return rubrics.Compile(offset, chunk);
    }

    public InstantSeriesMath Clone()
    {
        return new InstantSeriesMath(rubrics);
    }

    public MathRubrics Rubrics => rubrics;

    private Uscn serialcode;
    public Uscn SerialCode
    {
        get => serialcode;
        set => serialcode = value;
    }
    public IUnique Empty => Uscn.Empty;

    public long Id
    {
        get => serialcode.Id;
        set => serialcode.Id = value;
    }

    public int CompareTo(IUnique other)
    {
        return serialcode.CompareTo(other);
    }

    public bool Equals(IUnique other)
    {
        return serialcode.Equals(other);
    }

    public byte[] GetBytes()
    {
        return serialcode.GetBytes();
    }

    public byte[] GetIdBytes()
    {
        return serialcode.GetIdBytes();
    }

    public long TypeId
    {
        get => serialcode.TypeId;
        set => serialcode.TypeId = value;
    }

    public string CodeNo
    {
        get => serialcode.CodeNo;
        set => serialcode.CodeNo = value;
    }
}
