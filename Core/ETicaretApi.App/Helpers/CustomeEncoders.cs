using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace ETicaretApi.App.Helpers
{
    public  static class CustomeEncoders
    {
        public static string UrlCode(this string value)
        {
     
         byte[] bytes = Encoding.UTF8.GetBytes(value);
         return WebEncoders.Base64UrlEncode(bytes);
                
        }
        public static string UrlDecode(this string value)
        {
          byte[] bytes =WebEncoders.Base64UrlDecode(value);

          return Encoding.UTF8.GetString(bytes);

        }
    }
}