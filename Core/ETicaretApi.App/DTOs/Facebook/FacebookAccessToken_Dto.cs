using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETicaretApi.App.DTOs.Facebook
{
    public class FacebookAccessToken_Dto
    {

        [JsonPropertyName("access_token")]
        public string AccessToken {get; set;}
         [JsonPropertyName("token_type")]
        public string TokenType {get; set;}
    }
}