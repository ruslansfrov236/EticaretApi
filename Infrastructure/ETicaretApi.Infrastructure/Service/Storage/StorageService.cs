using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace ETicaretApi.Infrastructure.Service.Storage
{
   public class StorageService : IStorageService
   {

    readonly private IStorage _storage;

    public StorageService(IStorage storage)
    {
        _storage=storage;
    }

      public string StorageName { get => _storage.GetType().Name;  }

      public async Task DeleteAync(string fileName, string pathOrContainerName)
       => await _storage.DeleteAync(fileName ,pathOrContainerName );

      public List<string> GetFiles(string pathOrContainerName)
      => _storage.GetFiles(pathOrContainerName);

      public bool HasFileAsync(string pathOrContainerName, string fileName)
      =>  _storage.HasFileAsync(fileName , pathOrContainerName);

      public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
      => _storage.UploadAsync(pathOrContainerName , files);

    
   }
}