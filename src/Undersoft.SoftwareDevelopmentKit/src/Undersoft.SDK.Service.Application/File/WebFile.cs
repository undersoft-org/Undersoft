
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Undersoft.SDK.Service.Data.File.Container;
using Microsoft.AspNetCore.Http;
using Undersoft.SDK.Service.Data.File;

namespace Undersoft.SDK.Service.Application.File
{
    public class WebFile : DataFile, IFormFile, IWebFile
    {
        private IFormFile _formFile;
        private Stream _stream;

        public WebFile(FileContainer container, string filename) : base(container.ContainerName)
        {
            var task = GetOrNullAsync(filename);
            task.Wait();
            _stream = task.Result;
            _formFile = new FormFile(_stream, 0, _stream.Length, filename.Split('.')[0], filename);
        }
        public WebFile(string containerName, string filename) : base(containerName)
        {
            var task = GetOrNullAsync(filename);
            task.Wait();
            _stream = task.Result;
            _formFile = new FormFile(_stream, 0, _stream.Length, filename.Split('.')[0], filename);
        }
        public WebFile(string path) : base(Path.GetDirectoryName(path))
        {
            var filename = Path.GetFileName(path);
            var task = GetOrNullAsync(filename);
            task.Wait();
            _stream = task.Result;
            _formFile = new FormFile(_stream, 0, _stream.Length, filename.Split('.')[0], filename);
        }

        public override string ContentType => _formFile.ContentType;

        public override string ContentDisposition => _formFile.ContentDisposition;

        public IHeaderDictionary Headers => _formFile.Headers;

        public override long Length => _formFile.Length;

        public override string Name => _formFile.Name;

        public override string FileName => _formFile.FileName;

        public override void CopyTo(Stream target)
        {
            _formFile.CopyTo(target);
        }

        public override Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return _formFile.CopyToAsync(target, cancellationToken);
        }

        public override Stream OpenReadStream()
        {
            return _formFile.OpenReadStream();
        }
    }
}
