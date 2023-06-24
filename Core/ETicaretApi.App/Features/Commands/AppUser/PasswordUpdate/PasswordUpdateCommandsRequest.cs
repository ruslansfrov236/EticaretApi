using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.PasswordUpdate
{
    public class PasswordUpdateCommandsRequest:IRequest<PasswordUpdateCommandsResponse>
    {
        public string userId {get; set;}
        public string resetToken  {get; set;}
        public string newPassword {get; set;}
        public string PasswordConfirmed {get; set;}
    }
}