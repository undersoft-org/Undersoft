
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Undersoft.SDK.Service.Data.File.Container;

namespace Undersoft.SDK.Service.Data.File
{
    public class DataFile : FileContainer
    {
        private Stream _stream;

        public DataFile(FileContainer container, string filename) : this(container.ContainerName, filename)
        {
        }
        public DataFile(string containerName, string filename) : base(containerName)
        {
            var task = GetOrNullAsync(filename);
            task.Wait();
            _stream = task.Result;
            Name = filename.Split('.')[0];
            FileName = filename;
            Length = _stream.Length;
        }
        public DataFile(string path) : this(Path.GetDirectoryName(path), Path.GetFileName(path))
        {
        }

        public Stream Stream => _stream;

        public string ContentType { get; set; }

        public string ContentDisposition { get; set; }

        public long Length { get; set; }

        public string Name { get; set; }

        public string FileName { get; set; }

        public void CopyTo(Stream target)
        {
            _stream.CopyTo(target);
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return _stream.CopyToAsync(target, cancellationToken);
        }

        public Stream OpenReadStream()
        {
            return _stream;
        }
    }
}
