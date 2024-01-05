using Microsoft.AspNetCore.Http;
using Undersoft.SDK.Service.Data.File;

namespace Undersoft.SDK.Service.Application.File
{
    public interface IWebFile : IDataFile
    {
        IHeaderDictionary Headers { get; }
    }
}