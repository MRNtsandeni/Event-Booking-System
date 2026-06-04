using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Services
{
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string[] _permittedExtensions = { ".jpg", ".jpeg", ".png" };
        private const long _maxFileSize = 2 * 1024 * 1024; // 2MB constraint [cite: 7, 10]

        public BlobService(IConfiguration configuration)
        {
            // This reads "UseDevelopmentStorage=true" from appsettings.json 
            _blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("StorageConnectionString"));
        }

        public async Task<string> UploadFileAsync(IFormFile file, string containerName)
        {
            if (file == null || file.Length == 0) throw new Exception("File is empty.");
            if (file.Length > _maxFileSize) throw new Exception("File too large.");
            if (!_permittedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                throw new Exception("Invalid file type.");

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
            await blobClient.UploadAsync(file.OpenReadStream());
            return blobClient.Uri.ToString();
        }

       
        public async Task DeleteBlobAsync(string fileUrl, string containerName) // Added delete method [cite: 9]
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(Path.GetFileName(new Uri(fileUrl).LocalPath));
            await blobClient.DeleteIfExistsAsync();
        }
    }
}