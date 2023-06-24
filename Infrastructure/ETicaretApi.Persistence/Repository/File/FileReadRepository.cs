using E=ETicaretApi.Domain.Entity;
using ETicaretApi.App.Repository.File;
using ETicaretApi.Persistence.Context;

namespace ETicaretApi.Persistence.Repository.File
{
   public class FileReadRepository : ReadRepository<E.File>, IFileReadRepository
   {
      public FileReadRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}