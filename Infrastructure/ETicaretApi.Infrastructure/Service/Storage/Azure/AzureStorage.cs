using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ETicaretApi.App.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ETicaretApi.Infrastructure.Service.Storage.Azure
{
   public class AzureStorage :Storage, IAzureStorage
   {

    readonly private BlobServiceClient _blobServiceClient;
    BlobContainerClient _blobContainerClient;

      public AzureStorage(IConfiguration configuration )
      {
  
        _blobServiceClient=new(configuration["Storage:Azure"]);
      

      }
      public async Task DeleteAync(string fileName, string containerName)
      {
             _blobContainerClient=  _blobServiceClient.GetBlobContainerClient(containerName);
          BlobClient  blobClient=  _blobContainerClient.GetBlobClient(fileName);
          await blobClient.DeleteAsync();

      }

      public List<string> GetFiles(string containerName)
      {
         _blobContainerClient=  _blobServiceClient.GetBlobContainerClient(containerName);
           return   _blobContainerClient.GetBlobs().Select(b=>b.Name).ToList();

      }

      public bool HasFileAsync(string containerName, string fileName)
      {
         _blobContainerClient=  _blobServiceClient.GetBlobContainerClient(containerName);
           return   _blobContainerClient.GetBlobs().Any(b=>b.Name==fileName);
      }

      public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
      {
           _blobContainerClient=  _blobServiceClient.GetBlobContainerClient(containerName);

           await _blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);

           List<(string fileName, string pathOrContainerName)> datas= new();
           foreach (IFormFile file in files)
           {
           string fileNewName= await   FileRenameAsync(containerName , file.Name , HasFileAsync);
           BlobClient blobClient= _blobContainerClient.GetBlobClient(fileNewName);
           await  blobClient.UploadAsync(file.OpenReadStream());
            // burda tam melumati alir  datas.Add((fileNewName , containerName));
            datas.Add((fileNewName ,$"{containerName}/{file.Name}"));

           }

           return datas;
      }
   }
}