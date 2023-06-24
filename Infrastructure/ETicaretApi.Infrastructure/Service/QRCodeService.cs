using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using QRCoder;

namespace ETicaretApi.Infrastructure.Service
{
    public class QRCodeService:IQRCodeService
    {
   

      public byte[] GenerateQRCodeAsync(string text)
      {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData data= generator.CreateQrCode(text , QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode= new PngByteQRCode(data);
           byte[] byteGraphic= qRCode.GetGraphic(10 , new  byte[]{84, 99, 71} , new byte[]{240 , 240 , 240});
         return byteGraphic;
      }
   }
}