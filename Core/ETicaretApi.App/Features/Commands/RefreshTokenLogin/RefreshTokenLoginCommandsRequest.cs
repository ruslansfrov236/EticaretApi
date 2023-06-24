using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.DTOs;
using MediatR;

namespace ETicaretApi.App.Features.Commands.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandsRequest:IRequest<RefreshTokenLoginCommandsResponse>
    {
       public string? RefreshToken {get; set;}
    }
}