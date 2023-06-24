
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.FacebookLogin
{

   
    public class FacebookLoginCommandsRequest:IRequest<FacebookLoginCommandsResponse>
    {
        
        public string? AuthToken {get; set;}
   
    }
}