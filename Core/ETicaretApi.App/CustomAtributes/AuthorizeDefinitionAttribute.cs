
using ETicaretApi.App.Enums;

namespace ETicaretApi.App.CustomAtributes
{
    public class AuthorizeDefinitionAttribute:Attribute
    {
        public string Menu{get; set;}
        public string Definition{get; set;}

        public ActionType ActionType {get; set;}
   
    }
}