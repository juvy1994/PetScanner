using Azure.Storage.Blobs;

using Microsoft.AspNetCore.Http;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using Microsoft.Extensions.Configuration;

using PS.Infrastructure.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Services
{
    public class ImageAnalysisService : IImageAnalysisService
    {
        private readonly IConfiguration _configuration;

        public ImageAnalysisService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> UploadToBlobAsync(IFormFile file)
        {
            var connectionString = _configuration["AzureBlob:ConnectionString"];
            var containerName = _configuration["AzureBlob:ContainerName"];

            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();
            await containerClient.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var blobClient = containerClient.GetBlobClient(filename);

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, overwrite: true);

            return blobClient.Uri.ToString();
        }
    }
}
