using E=ETicaretApi.Domain.Entity;


using ETicaretApi.App.Repository.InvoiceFile;
using ETicaretApi.Persistence.Context;

namespace ETicaretApi.Persistence.Repository.InvoiceFile
{
   public class InvoiceFileReadRepository : ReadRepository<E.InvoiceFile>, IInvoiceFileReadRepository
   {
      public InvoiceFileReadRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}