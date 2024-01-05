namespace Undersoft.SDK.Service.Data.File
{
    public interface IDataFile
    {
        string ContentDisposition { get; }
        string ContentType { get; }
        string FileName { get; }
        long Length { get; }
        string Name { get; }
        Stream Stream { get; }

        void CopyTo(Stream target);
        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default);
        Stream OpenReadStream();
    }
}