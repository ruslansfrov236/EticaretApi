using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entity.Common;

namespace ETicaretApi.Domain.Entity
{
    public class File:BaseEntity
    {
        public string FileName {get; set;}
        public string Path {get; set;}
        public string Storage {get ; set;}

        [NotMapped]
       public override DateTime UpdatedDate {get=>base.UpdatedDate; set=>base.UpdatedDate=value;}  
    }
}