using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.DTOs.User
{
    public class CreateUser
    {
        public string? NameSurname {get; set;}
        public string? UserName {get; set;}
        public string? Email {get; set;}
        public string? Password{get; set;}
        public string? RePassword {get; set;}
    }
}