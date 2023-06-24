using E=ETicaretApi.Domain.Entity;
using ETicaretApi.App.Repository.InvoiceFile;
using ETicaretApi.Persistence.Context;

namespace ETicaretApi.Persistence.Repository.InvoiceFile
{
   public class InvoiceFileWriteRepository : WriteRepository<E.InvoiceFile>, IInvoiceFileWriteRepository
   {
      public InvoiceFileWriteRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}