
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Undersoft.SDK.Service.Data.File.Container;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Primitives;
using System.Runtime.Serialization;

namespace Undersoft.SDK.Service.Data.File
{
    public class DataFile : FileContainer, IDataFile
    {
        Stream _stream;

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

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Stream Stream => _stream;

        public virtual string ContentType { get; set; }

        public virtual string ContentDisposition { get; set; }

        public virtual long Length { get; set; }

        public virtual string Name { get; set; }

        public virtual string FileName { get; set; }

        public virtual void CopyTo(Stream target)
        {
            _stream.CopyTo(target);
        }

        public virtual Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return _stream.CopyToAsync(target, cancellationToken);
        }

        public virtual Stream OpenReadStream()
        {
            return _stream;
        }
    }
}
