using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Abstractions.Services
{
    public interface IQRCodeService
    {
        byte[] GenerateQRCodeAsync( string text);
    }
}