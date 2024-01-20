﻿namespace Undersoft.SDK.Instant.Series
{
    using Instant.Proxies;
    using SDK.Series;
    using SDK.Series.Base;
    using Uniques;
    using Rubrics;
    using System.IO;
    using System.Linq;
    using Querying;
    using Math;
    using Undersoft.SDK.Instant.Math;

    public abstract class InstantRegistry : RegistryBase<IInstant>, IInstantSeries
    {
        public IInstantCreator Instant { get; set; }

        public abstract bool Prime { get; set; }

        public abstract object this[int index, string propertyName] { get; set; }

        public abstract object this[int index, int fieldId] { get; set; }

        public abstract IRubrics Rubrics { get; set; }

        public abstract IRubrics KeyRubrics { get; set; }

        public abstract IInstant NewInstant();

        public abstract IProxy NewProxy();

        public abstract Type InstantType { get; set; }

        public abstract int InstantSize { get; set; }

        public abstract Uscn Code { get; set; }

        public override ISeriesItem<IInstant> EmptyItem()
        {
            return new InstantSeriesItem();
        }

        public override ISeriesItem<IInstant> NewItem(long key, IInstant value)
        {
            return new InstantSeriesItem(key, value);
        }

        public override ISeriesItem<IInstant> NewItem(object key, IInstant value)
        {
            return new InstantSeriesItem(key, value);
        }

        public override ISeriesItem<IInstant> NewItem(IInstant value)
        {
            return new InstantSeriesItem(value);
        }

        public override ISeriesItem<IInstant> NewItem(ISeriesItem<IInstant> value)
        {
            return new InstantSeriesItem(value);
        }

        public override ISeriesItem<IInstant>[] EmptyTable(int size)
        {
            return new InstantSeriesItem[size];
        }

        public override ISeriesItem<IInstant>[] EmptyVector(int size)
        {
            return new InstantSeriesItem[size];
        }

        protected override bool InnerAdd(IInstant value)
        {
            return InnerAdd(NewItem(value));
        }

        protected override ISeriesItem<IInstant> InnerPut(IInstant value)
        {
            return InnerPut(NewItem(value));
        }

        public override ISeriesItem<IInstant> New()
        {
            ISeriesItem<IInstant> newItem = NewItem(Unique.NewId, NewInstant());
            if (InnerAdd(newItem))
                return newItem;
            return null;
        }

        public override ISeriesItem<IInstant> New(long key)
        {
            ISeriesItem<IInstant> newItem = NewItem(key, NewInstant());
            if (InnerAdd(newItem))
                return newItem;
            return null;
        }

        public override ISeriesItem<IInstant> New(object key)
        {
            ISeriesItem<IInstant> newItem = NewItem(unique.Key(key), NewInstant());
            if (InnerAdd(newItem))
                return newItem;
            return null;
        }

        public object[] ValueArray
        {
            get => ToObjectArray();
            set => Put(value);
        }

        public Type Type { get; set; }

        public IQueryable<IInstant> View { get; set; }

        public IInstant Total { get; set; }

        public InstantSeriesFilter Filter { get; set; }

        public InstantSeriesSort Sort { get; set; }

        public Func<IInstant, bool> Predicate { get; set; }

        private InstantSeriesAggregate aggregate;
        public InstantSeriesAggregate Aggregate
        {
            get => aggregate == null ? aggregate = new InstantSeriesAggregate(this) : aggregate;
            set => aggregate = value;
        }

        public ISeries<IInstantMath> Computations { get; set; }

        object IInstant.this[int fieldId]
        {
            get => this[fieldId];
            set => this[fieldId] = (IInstant)value;
        }
        public object this[string propertyName]
        {
            get => this[propertyName];
            set => this[propertyName] = (IInstant)value;
        }

        public override byte[] GetBytes()
        {
            return Code.GetBytes();
        }

        public override byte[] GetIdBytes()
        {
            return Code.GetIdBytes();
        }

        public override bool Equals(IUnique other)
        {
            return Code.Equals(other);
        }

        public override int CompareTo(IUnique other)
        {
            return Code.CompareTo(other);
        }

        public int SerialCount { get; set; }
        public int DeserialCount { get; set; }
        public int ProgressCount { get; set; }

        public int Serialize(
            Stream stream,
            int offset,
            int batchSize
        )
        {
            throw new NotImplementedException();
        }

        public int Serialize(
            byte[] buffor,
            int offset,
            int batchSize
        )
        {
            throw new NotImplementedException();
        }

        public object Deserialize(Stream stream)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(
           byte[] buffer
        )
        {
            throw new NotImplementedException();
        }

        public object[] GetMessage()
        {
            return new[] { (IInstantSeries)this };
        }

        public object GetHeader()
        {
            return this;
        }

        public int ItemsCount => Count;
    }
}
