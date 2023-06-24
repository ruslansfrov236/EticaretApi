using E=ETicaretApi.Domain.Entity;
using ETicaretApi.App.Repository.ProductImageFile;
using ETicaretApi.Persistence.Context;

namespace ETicaretApi.Persistence.Repository.ProductImageFile
{
   public class ProductImageReadRepository : ReadRepository<E.ProductImage>, IProductImageReadRepository
   {
      public ProductImageReadRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}