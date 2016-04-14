using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BlobService : BaseStorageService
    {
        public BlobService()
        {

        }

        public async Task Upload(Stream stream, string blobName)
        {
            CloudBlobClient blobClient = _account.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("images");

            await container.CreateIfNotExistsAsync();

            SetContainerPermission(container);

            CloudBlockBlob blob = container.GetBlockBlobReference(blobName);
            
            await blob.UploadFromStreamAsync(stream);
        }

        public async Task<List<Image>> List()
        {
            List<Image> images = new List<Image>();

            CloudBlobClient blobClient = _account.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("images");

            await container.CreateIfNotExistsAsync();

            SetContainerPermission(container);

            IEnumerable<IListBlobItem> blobs = container.ListBlobs();

            foreach(IListBlobItem blob in blobs)
            {
                images.Add(new Image
                {
                    Url = blob.Uri.AbsoluteUri                    
                });
            }
            return images;
        }

        private static void SetContainerPermission(CloudBlobContainer container)
        {
            BlobContainerPermissions permission = container.GetPermissions();
            permission.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permission);
        }
    }
}