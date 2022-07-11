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
            fileStream.Position = 0; // Stream is one way, data is written till the end, so position need to be reset to the start for pointer to read
            // Upload the file
            await blob.UploadAsync(fileStream, overwrite: true);

            return await Task.FromResult(true);
        }

        public static async Task<bool> RetrieveFileFromStorage(Product Product, string blobStorageContainerName, IWebHostEnvironment webEnv)
        {
            // Create the blob client.
            var blobContainerClient = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);

            // Create a local file in the ./data/ directory for uploading and downloading
            string localPath = Path.Combine(webEnv.WebRootPath, "data");
            Directory.CreateDirectory(localPath); // Create directory if !exist, otherwise ignore
            string fileName = Product.Image;
            string localFilePath = Path.Combine(localPath, fileName);

            var blob = blobContainerClient.GetBlobClient(fileName); // Create a new BlobClient object by appending blobName to the end of Uri. 
            // Download the blob's contents and save it to a file
            await blob.DownloadToAsync(localFilePath);

            return await Task.FromResult(true);
        }

        public static async void DeleteFileFromStorage(Product Product, string blobStorageContainerName, IWebHostEnvironment webEnv)
        {
            // Create the blob client.
            var blobContainerClient = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);

            string localPath = Path.Combine(webEnv.WebRootPath, "data");
            string fileName = Product.Image;
            string localFilePath = Path.Combine(localPath, fileName);

            var blob = blobContainerClient.GetBlobClient(fileName); // Find the blob on Azure Blob Storage

            // Delete the blob from Azure Blob Storage
            await blob.DeleteIfExistsAsync();

            // Delete the image from webroot's data folder
            if (File.Exists(localFilePath))
            {
                File.Delete(localFilePath);
            }
        }
    }
}
