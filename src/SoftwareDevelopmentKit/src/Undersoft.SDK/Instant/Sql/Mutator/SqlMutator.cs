namespace Undersoft.SDK.Instant.Sql
{
    using Undersoft.SDK.Instant.Series;
    using Undersoft.SDK.Series;

    public class SqlMutator
    {
        private InstantSqlDb sqaf;

        public SqlMutator() { }

        public SqlMutator(InstantSqlDb insql)
        {
            sqaf = insql;
        }

        public ISeries<ISeries<IInstant>> Delete(string SqlConnectString, IInstantSeries cards)
        {
            try
            {
                if (sqaf == null)
                    sqaf = new InstantSqlDb(SqlConnectString);
                try
                {
                    bool buildmap = true;
                    if (cards.Count > 0)
                    {
                        BulkPrepareType prepareType = BulkPrepareType.Drop;
                        return sqaf.Delete(cards, true, buildmap, prepareType);
                    }
                    return null;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ISeries<ISeries<IInstant>> Set(string SqlConnectString, IInstantSeries cards, bool Renew)
        {
            try
            {
                if (sqaf == null)
                    sqaf = new InstantSqlDb(SqlConnectString);
                try
                {
                    bool buildmap = true;
                    if (cards.Count > 0)
                    {
                        BulkPrepareType prepareType = BulkPrepareType.Drop;

                        if (Renew)
                            prepareType = BulkPrepareType.Trunc;

                        var ds = sqaf.Update(cards, true, buildmap, true, null, prepareType);
                        if (ds != null)
                        {
                            IInstantSeries im = (IInstantSeries)Instances.New(cards.GetType());
                            im.Rubrics = cards.Rubrics;
                            im.InstantType = cards.InstantType;
                            im.InstantSize = cards.InstantSize;
                            im.Add(ds["Failed"].AsValues());
                            return sqaf.Insert(im, true, false, prepareType);
                        }
                        else
                            return null;
                    }
                    return null;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
