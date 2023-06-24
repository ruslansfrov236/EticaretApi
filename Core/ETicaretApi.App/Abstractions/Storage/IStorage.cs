using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ETicaretApi.App.Abstractions.Storage
{
    public interface IStorage
    {
        
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
        Task DeleteAync(string fileName, string pathOrContainerName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFileAsync( string pathOrContainerName, string fileName);
    }
}