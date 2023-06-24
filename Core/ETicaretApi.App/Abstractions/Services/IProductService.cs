using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Abstractions.Services
{
    public interface IProductService
    {
        Task <byte[]> ProductQrCodeAsync(string productId);
        Task StockUpdateToProductAsync( string productId , int  stock);
    }
}