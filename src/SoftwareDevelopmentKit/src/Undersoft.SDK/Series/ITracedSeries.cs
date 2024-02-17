namespace Undersoft.SDK.Series
{
    using Invoking;
    using Instant.Updating;
    using Undersoft.SDK.Updating;

    public interface ITracedSeries
    {
        IUpdater Updater { get; }

        IInvoker NoticeChange { get; }

        IInvoker NoticeChanging { get; }
    }
}
