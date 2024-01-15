using Microsoft.AspNetCore.Http;
using Undersoft.SDK.Service.Data.File;

namespace Undersoft.SDK.Service.Server.File
{
    public interface IServerFile : IDataFile
    {
        IHeaderDictionary Headers { get; }
    }
}