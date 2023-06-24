using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Infrastructure.Operations
{
    public static class NameOperations
    {
        public static string CharacterRegulatory(string name)
=>
name
    .Replace("\"", "")
    .Replace("!", "")
    .Replace("'", "")
    .Replace("^", "")
    .Replace("+", "")
    .Replace("-", "")
    .Replace(">", "")
    .Replace("<", "")
    .Replace(":", "")
    .Replace("/", "")
    .Replace("(", "")
    .Replace(")", "")
    .Replace("@", " ")
    .Replace("#", " ")
    .Replace("$", " ")
    .Replace("%", " ")
    .Replace("&", " ")
    .Replace("*", " ")
    .Replace("`", " ")
    .Replace("~", " ")
    .Replace("_", " ")
    .Replace("-", " ")
    .Replace("|", " ")
    .Replace(";", " ")
    .Replace("#", " ")
    .Replace("№", " ")
    .Replace(".", "-")
    .Replace(",", " ")
    .Replace("ç", "c")
    .Replace("ş", "s")
    .Replace("ə", "e")
    .Replace("ö", "o")
    .Replace("ğ", "g")
    .Replace("ü", "u")
    .Replace("ı", "i")
    .Replace("Ç", "c")
    .Replace("Ş", "s")
    .Replace("I", "i")
    .Replace("Ə", "e")
    .Replace("Ö", "o")
    .Replace("Ğ", "g")
    .Replace("Ü", "u");

    }
}

