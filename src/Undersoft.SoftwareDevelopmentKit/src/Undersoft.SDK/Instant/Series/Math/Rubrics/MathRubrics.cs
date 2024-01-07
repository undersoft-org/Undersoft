namespace Undersoft.SDK.Instant.Series.Math.Rubrics
{
    using System.Linq;
    using SDK.Series;
    using SDK.Series.Base;
    using Set;
    using Instant.Rubrics;

    public class MathRubrics : RegistrySeries<MathRubric>
    {
        public MathRubrics(IInstantSeries data)
        {
            Rubrics = data.Rubrics;
            FormulaRubrics = new MathRubrics(Rubrics);
            MathsetRubrics = new MathRubrics(Rubrics);
            Data = data;
        }

        public MathRubrics(IRubrics rubrics)
        {
            Rubrics = rubrics;
            Data = rubrics.Figures;
        }

        public MathRubrics(MathRubrics rubrics)
        {
            Rubrics = rubrics.Rubrics;
            Data = rubrics.Data;
        }

        public IInstantSeries Data { get; set; }

        public MathRubrics FormulaRubrics { get; set; }

        public MathRubrics MathsetRubrics { get; set; }

        public int RowsCount
        {
            get { return Data.Count; }
        }

        public IRubrics Rubrics { get; set; }

        public int RubricsCount
        {
            get { return Rubrics.Count; }
        }

        public bool Combine(int offset = 0, int batch = 0)
        {
            if (!ReferenceEquals(Data, null))
            {
                CompiledMathSet[] evs = CombineEvaluators();
                evs.ForEach(e => e.SetParams(Data, 0, offset, batch));
                return true;
            }
            else
                CombineEvaluators();
            return false;
        }

        public bool Combine(IInstantSeries table, int offset = 0, int batch = 0)
        {
            if (!ReferenceEquals(Data, table))
            {
                Data = table;
                CompiledMathSet[] evs = CombineEvaluators();
                evs.ForEach(e => e.SetParams(Data, 0, offset, batch));
                return true;
            }
            else
                CombineEvaluators();
            return false;
        }

        public bool CombineChunk(IInstantSeries table, int offset = 0, int batch = 0)
        {
            if (!ReferenceEquals(Data, table))
            {
                Data = table;
                CompiledMathSet[] evs = GetCompiledMathSets();
                evs.ForEach(e => e.SetParams(Data, 0, offset, batch));
                return true;
            }
            else
                GetCompiledMathSets();
            return false;
        }

        public CompiledMathSet[] CombineEvaluators()
        {
            return this.AsValues().Select(m => m.CombineEvaluator()).ToArray();
        }

        public CompiledMathSet[] GetCompiledMathSets()
        {
            return this.AsValues().Select(m => m.GetCompiledMathSet()).ToArray();
        }

        public override ISeriesItem<MathRubric>[] EmptyVector(int size)
        {
            return new MathRubricItem[size];
        }

        public override ISeriesItem<MathRubric> EmptyItem()
        {
            return new MathRubricItem();
        }

        public override ISeriesItem<MathRubric>[] EmptyTable(int size)
        {
            return new MathRubricItem[size];
        }

        public override ISeriesItem<MathRubric> NewItem(ISeriesItem<MathRubric> value)
        {
            return new MathRubricItem(value);
        }

        public override ISeriesItem<MathRubric> NewItem(MathRubric value)
        {
            return new MathRubricItem(value);
        }

        public override ISeriesItem<MathRubric> NewItem(object key, MathRubric value)
        {
            return new MathRubricItem(key, value);
        }

        public override ISeriesItem<MathRubric> NewItem(long key, MathRubric value)
        {
            return new MathRubricItem(key, value);
        }
    }
}
