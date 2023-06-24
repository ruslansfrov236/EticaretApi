using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace ETicaretApi.WebApi.Configuration.ColumnWrites
{
   public class UsernameColumnWriter : ColumnWriterBase

   {
      public UsernameColumnWriter() : base(NpgsqlDbType.Varchar)
      {
      }

      public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
      {

         
         var (username, value) = logEvent.Properties.FirstOrDefault(p => p.Key == "user_name");
         
             return value?.ToString() ?? null;
         
           
      }
   }
}