﻿namespace Undersoft.SDK.Instant.Series.Math.Set
{
    using System.Reflection.Emit;
    using Formulas;
    using Rubrics;

    [Serializable]
    public class MathSet : LeftFormula
    {
        [NonSerialized]
        private InstantSeriesMathCompilerContext context;

        public MathSet(MathRubric rubric)
        {
            Rubric = rubric;
            Formuler = rubric.Formuler;
        }

        public MathSet Formuler { get; set; }
        public SubMathSet SubFormuler { get; set; }
        public Formula Formula
        {
            get => Rubric.Formula;
            set => Rubric.Formula = value;
        }
        public Formula PartialFormula;
        public Mathstage SubFormula;

        public bool PartialMathset = false;

        public IInstantSeries Data
        {
            get => Rubric.MathsetRubrics.Data;
        }

        public MathRubrics Rubrics
        {
            get => Rubric.FormulaRubrics;
            set => Rubric.FormulaRubrics = value;
        }
        public MathRubric Rubric { get; set; }

        public string RubricName
        {
            get => Rubric.RubricName;
        }
        public Type RubricType
        {
            get => Rubric.RubricType;
        }
        public int FieldId
        {
            get => Rubric.FigureFieldId;
        }

        public int rowCount { get; set; }
        public int colCount
        {
            get => Rubrics.Count;
        }

        public int startId = 0;

        public MathRubric AssignRubric(string name)
        {
            return Rubric.AssignRubric(name);
        }

        public MathRubric AssignRubric(int ordinal)
        {
            return Rubric.AssignRubric(ordinal);
        }

        public MathRubric RemoveRubric(string name)
        {
            return Rubric.AssignRubric(name);
        }

        public void AssignContext(InstantSeriesMathCompilerContext Context)
        {
            if (context == null || !ReferenceEquals(context, Context))
                context = Context;
        }

        public MathSet Clone()
        {
            MathSet mx = (MathSet)this.MemberwiseClone();
            return mx;
        }

        public double this[long index]
        {
            get
            {
                int length = Data.GetType().GetFields().Length - 1;
                return Convert.ToDouble((Data[(int)index / length])[(int)index % length]);
            }
            set
            {
                int length = Data.GetType().GetFields().Length - 1;
                (Data[(int)index / length])[(int)index % length] = value;
            }
        }
        public double this[long index, long field]
        {
            get { return Convert.ToDouble(Data[(int)index, (int)field]); }
            set { Data[(int)index, (int)field] = value; }
        }
        public SubMathSet this[string name]
        {
            get
            {
                if (SubFormula == null)
                    SubFormula = new Mathstage(this);
                return SubFormula[name];
            }
        }
        public SubMathSet this[int r, string name]
        {
            get
            {
                if (SubFormula == null)
                    SubFormula = new Mathstage(this, r, r);
                return SubFormula[name];
            }
        }
        public Mathstage this[int r]
        {
            get { return new Mathstage(this, r, r); }
        }
        public Mathstage this[IndexRange q]
        {
            get { return new Mathstage(this, q.first, q.last); }
        }

        public static IndexRange Range(int i1, int i2)
        {
            return new IndexRange(i1, i2);
        }

        public override void CompileAssign(
            ILGenerator g,
            InstantSeriesMathCompilerContext cc,
            bool post,
            bool partial
        )
        {
            if (cc.IsFirstPass())
            {
                cc.Add(Data);
                PartialFormula = Formula.RightFormula.Prepare(this[RubricName], false);
                PartialFormula.Compile(g, cc);
                Rubric.PartialMathset = true;
            }
            else
            {
                PartialFormula.Compile(g, cc);
            }
        }

        public override void Compile(ILGenerator g, InstantSeriesMathCompilerContext cc)
        {
            if (cc.IsFirstPass())
            {
                cc.Add(Data);
                PartialFormula = Formula.RightFormula.Prepare(this[RubricName], true);
                PartialFormula.Compile(g, cc);
                Rubric.PartialMathset = true;
            }
            else
            {
                PartialFormula.Compile(g, cc);
            }
        }

        public override MathSetSize Size
        {
            get { return new MathSetSize(Data.Count, Rubrics.Count); }
        }

        public void SetDimensions(SubMathSet sm, MathSet mx = null, int offset = 0)
        {
            sm.startId = offset;
            sm.SetDimensions(mx);
        }

        public SubMathSet GetAll(MathRubric rubric)
        {
            SubMathSet smx = new SubMathSet(rubric, this);
            return smx;
        }

        public SubMathSet GetRange(int startRowId, int endRowId, MathRubric rubric)
        {
            startId = startRowId;
            rowCount = (endRowId - startRowId) + 1;
            SubMathSet smx = new SubMathSet(rubric, this);
            return smx;
        }

        public SubMathSet GetColumn(int j)
        {
            return GetRange(0, j, null);
        }

        public SubMathSet GetColumnCount(int j1, int j2)
        {
            return GetRange(0, 1, null);
        }

        public SubMathSet GetRow(int i)
        {
            return GetRange(i, 1, null);
        }

        public SubMathSet GetRowCount(int i1, int i2)
        {
            return GetRange(i1, i2, null);
        }

        public SubMathSet GetItems(int e1, int e2)
        {
            return new SubMathSet(null, this);
        }

        [Serializable]
        public class Mathstage
        {
            internal Mathstage(MathSet m)
            {
                formuler = m;
                firstRow = 0;
                rowCount = (m.rowCount - firstRow) - 1;
            }

            internal Mathstage(MathSet m, int startRowId, int endRowId)
            {
                firstRow = startRowId;
                rowCount = (endRowId - startRowId);
                formuler = m;
            }

            public SubMathSet this[int ordinal]
            {
                get
                {
                    MathRubric rubric = formuler.Rubric.AssignRubric(ordinal);
                    return formuler.GetAll(rubric);
                }
            }
            public SubMathSet this[string name]
            {
                get
                {
                    try
                    {
                        MathRubric rubric = formuler.Rubric.AssignRubric(name);
                        return formuler.GetAll(rubric);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }

            public static explicit operator LeftFormula(Mathstage r)
            {
                return r.formuler.GetItems(r.firstRow, r.lastRow);
            }

            private MathSet formuler;

            public int firstRow;
            public int rowCount = -1;
            public int lastRow
            {
                get
                {
                    return (formuler.rowCount > (firstRow + rowCount + 1) && rowCount > -1)
                        ? firstRow + rowCount
                        : formuler.rowCount - 1;
                }
            }
        }

        [Serializable]
        public struct IndexRange
        {
            internal IndexRange(int i1, int i2)
            {
                first = i1;
                last = i2;
            }

            internal int first,
                last;
        }
    }
}
