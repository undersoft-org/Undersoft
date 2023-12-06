﻿namespace Undersoft.SDK.Service.Data.File.Blob
{
    public class BlobNormalizeNaming
    {
        public string ContainerName { get; }

        public string BlobName { get; }

        public BlobNormalizeNaming(string containerName, string blobName)
        {
            ContainerName = containerName;
            BlobName = blobName;
        }
    }
}