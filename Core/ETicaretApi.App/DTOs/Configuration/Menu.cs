using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.DTOs.Configuration
{
    public class Menu
    {
        public string MenuName {get;set;}
        public List<Action> Actions{get;set;} =new();
    }
}