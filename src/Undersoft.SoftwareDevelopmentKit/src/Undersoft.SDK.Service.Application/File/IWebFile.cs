using Microsoft.AspNetCore.Http;

namespace Undersoft.SDK.Service.Application.File
{
    public interface IWebFile
    {
        string ContentDisposition { get; }
        string ContentType { get; }
        string FileName { get; }
        IHeaderDictionary Headers { get; }
        long Length { get; }
        string Name { get; }
        Stream Stream { get; }

        void CopyTo(Stream target);
        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default);
        Stream OpenReadStream();
    }
}