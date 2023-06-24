 using E=ETicaretApi.Domain.Entity;
using ETicaretApi.App.Repository.ProductImageFile;
using ETicaretApi.Persistence.Context;

namespace ETicaretApi.Persistence.Repository.ProductImageFile
{
   public class ProductImageWriteRepository : WriteRepository<E.ProductImage>, IProductImageWriteRepository
   {
      public ProductImageWriteRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}