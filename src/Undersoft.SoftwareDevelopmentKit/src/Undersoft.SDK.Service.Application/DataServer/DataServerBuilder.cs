using Undersoft.SDK.Series;
using System;
using Undersoft.SDK.Service.Data.Store;
using Microsoft.EntityFrameworkCore;

namespace Undersoft.SDK.Service.Application.DataServer
{ 
    public abstract class DataServerBuilder : Registry<Type>, IDataServerBuilder
    {
        protected virtual Type StoreType { get; set; }

        public static DataServerTypes ServiceTypes { get; set; }

        public string RoutePrefix { get; set; } = "";

        public int PageLimit { get; set; } = 10000;

        protected ISeries<Type> ContextTypes { get; set; } = new Catalog<Type>();

        public DataServerBuilder() : base()
        {
            RoutePrefix = GetRoutes();
        }

        public abstract void Build();

        protected virtual string GetRoutes()
        {
            if (StoreType == typeof(IEventStore))
            {
                return StoreRoutes.EventStoreRoute + RoutePrefix;
            }
            else
            {
                return StoreRoutes.DataStoreRoute + RoutePrefix;
            }
        }

        public virtual IDataServerBuilder AddDataServices<TContext>() where TContext : DbContext
        {
            TryAdd(typeof(TContext));
            return this;
        }

        public virtual IDataServerBuilder AddAuthorizationService()
        {
            return this;
        }

    }

    public enum DataServerTypes
    {
        None = 0,
        Grpc = 1,
        OData = 2,
        Rest = 4,
        All = 7
    }
}
