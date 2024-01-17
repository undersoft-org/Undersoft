using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Series.Base;

namespace Undersoft.SDK.Instant.Sql
{
    public class InstantSql<T> : RegistrySeries<IProxy<T>>
    {
        public InstantSql() { }

        public InstantSql(InstantSqlContext sqlcontext)
        {
            Context = sqlcontext;
        }
     
        public IInstantSeries InstantSeriesCreator { get; private set; }

        public InstantSqlContext Context { get; }
    }

    public class Sqlset : RegistrySeries<IProxy>
    {
        public Sqlset() { }

        public Sqlset(InstantSqlContext sqlcontext)
        {
            Context = sqlcontext;
        }

        public IInstantSeries InstantSeriesCreator { get; private set; }

        public InstantSqlContext Context { get; }
    }
}
