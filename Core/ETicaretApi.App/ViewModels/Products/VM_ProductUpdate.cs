
using ETicaretApi.Domain.Entity;

namespace ETicaretApi.App.ViewModels.Products
{
    public class VM_ProductUpdate
    {
        public string? Id {get; set;}
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}