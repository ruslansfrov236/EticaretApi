using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.DTOs.User
{
    public class ListUser
    {
        public string Id {get; set;}
        public string Email {get; set;}
        public string UserName {get; set;}
        public string NameSurName {get; set;}
        public bool TwoFactorEnabled {get; set;}
    }
}  