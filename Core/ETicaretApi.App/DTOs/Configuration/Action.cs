using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Enums;

namespace ETicaretApi.App.DTOs.Configuration
{
    public class Action
    {
        public string ActionType {get; set;}
        public string HttpType {get; set;}
        public string Definition {get; set;}
        public string Code {get; set;}
    }
}