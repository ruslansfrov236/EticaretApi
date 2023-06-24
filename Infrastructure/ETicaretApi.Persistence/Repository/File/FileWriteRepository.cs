
using E=ETicaretApi.Domain.Entity;
using ETicaretApi.App.Repository.File;
using ETicaretApi.Persistence.Context;

namespace ETicaretApi.Persistence.Repository.File
{
   public class FileWriteRepository : WriteRepository<E.File>, IFileWriteRepository
   {
      public FileWriteRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}