namespace Undersoft.SDK.Instant.Series.Math;

using SDK.Series;
using Uniques;
using System.Linq;
using Rubrics;
using Set;
using Instant.Rubrics;

public class InstantSeriesMath : IInstantSeriesMath
{
    private MathRubrics mathRubrics;

    public InstantSeriesMath(IInstantSeries data)
    {
        mathRubrics = new MathRubrics(data);
        serialcode.Id = (long)DateTime.Now.ToBinary();
        if (data.Computations == null)
            data.Computations = new Catalog<IInstantSeriesMath>();
        data.Computations.Put(this);
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
        MemberRubric rubric = mathRubrics.Rubrics[id];
        if (rubric != null)
        {
            MathRubric mathrubric = null;
            if (mathRubrics.MathsetRubrics.TryGet(rubric.Name, out mathrubric))
                return mathrubric.GetMathset();
            return mathRubrics
                .Put(rubric.Name, new MathRubric(mathRubrics, rubric))
                .Value.GetMathset();
        }
        return null;
    }

    public MathSet GetMathSet(string name)
    {
        MemberRubric rubric = null;
        if (mathRubrics.Rubrics.TryGet(name, out rubric))
        {
            MathRubric mathrubric = null;
            if (mathRubrics.MathsetRubrics.TryGet(name, out mathrubric))
                return mathrubric.GetMathset();
            return mathRubrics
                .Put(rubric.Name, new MathRubric(mathRubrics, rubric))
                .Value.GetMathset();
        }
        return null;
    }

    public MathSet GetMathSet(MemberRubric rubric)
    {
        return GetMathSet(rubric.Name);
    }

    public bool ContainsFirst(MemberRubric rubric)
    {
        return mathRubrics.First.Value.RubricName == rubric.Name;
    }

    public bool ContainsFirst(string rubricName)
    {
        return mathRubrics.First.Value.RubricName == rubricName;
    }

    public IInstantSeries Compute()
    {
        mathRubrics.Combine();
        mathRubrics
            .AsValues()
            .Where(p => !p.PartialMathset)
            .OrderBy(p => p.ComputeOrdinal)
            .Select(p => p.Compute())
            .ToArray();
        return mathRubrics.Data;
    }

    public IInstantSeries ComputeChunk(int offset, int chunk)
    {
        mathRubrics.Combine(offset, chunk);
        mathRubrics
            .AsValues()
            .Where(p => !p.PartialMathset)
            .OrderBy(p => p.ComputeOrdinal)
            .ForEach(p => p.Compute())
            .Commit();
        return mathRubrics.Data;
    }

    public InstantSeriesMath SetMathRubrics(MathRubrics rubrics)
    {
        mathRubrics = rubrics;
        return this;
    }

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

    public string CodeNo {
        get => serialcode.CodeNo;
        set => serialcode.CodeNo = value;
    }
}
