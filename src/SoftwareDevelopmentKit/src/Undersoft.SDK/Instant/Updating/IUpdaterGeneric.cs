namespace Undersoft.SDK.Instant.Updating
{
    public interface IUpdater<T> : IUpdater
    {
        T Devisor { get; set; }

        new T Clone();
        UpdatedItem[] Detect(T item);
        T Patch(T item);
        T PatchFrom(T source);
        T Put(T item);
        T PutFrom(T source);
    }
}
