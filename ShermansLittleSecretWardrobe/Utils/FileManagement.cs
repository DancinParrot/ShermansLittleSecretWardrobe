using Azure.Storage.Blobs;
using ShermansLittleSecretWardrobe.Models;
using System.Configuration;

namespace ShermansLittleSecretWardrobe.Utils
{
    public class FileManagement
    {
        private const string blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=shermansfiles;AccountKey=xHH6ps7xbvSEsKsiNmKxH+zCh8rhDlmJHo5gKUpnK+yBUi15AeSl/vIM69ts1AdJ4sgWT9GKBAJd+AStia7Kaw==;EndpointSuffix=core.windows.net";

        public static async Task<bool> UploadFileToStorage(Stream fileStream, string blobName, string blobStorageContainerName)
        {

            // Create the blob client.
            var blobContainerClient = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);
            var blob = blobContainerClient.GetBlobClient(blobName); // Create a new BlobClient object by appending blobName to the end of Uri. 
            fileStream.Position = 0;
            // Upload the file
            await blob.UploadAsync(fileStream);

            return await Task.FromResult(true);
        }

        public static async Task<bool> RetrieveFileFromStorage(Product product, string blobStorageContainerName)
        {
            // Create the blob client.
            var blobContainerClient = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);
            

            return await Task.FromResult(true);
        }
    }
}
