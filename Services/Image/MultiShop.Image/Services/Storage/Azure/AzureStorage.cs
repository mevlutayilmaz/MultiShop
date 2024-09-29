﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;
using MultiShop.Image.Settings;

namespace MultiShop.Image.Services.Storage.Azure
{
    public class AzureStorage : Storage, IAzureStorage
    {
        readonly StorageSettings _storageSettings;
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;
        public AzureStorage(IOptions<StorageSettings> storageSettings)
        {
            _storageSettings = storageSettings.Value;
            _blobServiceClient = new(_storageSettings.Azure.ConnectionString);
        }
        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainerName)> datas = new();
            foreach (IFormFile file in files)
            {
                string newfileName = await FileRenameAsync(containerName, file.FileName, HasFile);

                BlobClient blobClient = _blobContainerClient.GetBlobClient(newfileName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((newfileName, $"{_storageSettings.Azure.DomainUrl}/{containerName}/{newfileName}"));
            }
            return datas;
        }
    }
}
