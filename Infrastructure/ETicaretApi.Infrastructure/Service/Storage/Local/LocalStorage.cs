using ETicaretApi.App.Abstractions.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ETicaretApi.Infrastructure.Service.Storage.Local
{
   public class LocalStorage :Storage,  ILocalStorage
   {
       readonly private IWebHostEnvironment _webhostEnvironment;

     public LocalStorage( IWebHostEnvironment webhostEnvironment)
     {
        _webhostEnvironment=webhostEnvironment;
     }
      public async Task DeleteAync(string fileName, string path)
      =>File.Delete($"{path}\\{fileName}");

      public List<string> GetFiles(string path)
      {
        DirectoryInfo directoryInfo= new(path);
        return directoryInfo.GetFiles().Select(f=>f.Name).ToList();
      }

    
      
       
        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

      public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
      {
             string uploadPath = Path.Combine(_webhostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
           
            List<(string fileName, string path)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName= await   FileRenameAsync(path, file.Name , HasFileAsync);
                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((file.Name, $"{path}\\{fileNewName}"));
             
            }
          

            return datas;
      }

    

      public bool HasFileAsync(string path, string fileName)
        =>File.Exists($"{path}\\{fileName}");
   }
}