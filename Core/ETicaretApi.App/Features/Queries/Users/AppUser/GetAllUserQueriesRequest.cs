using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Users.AppUser
{
    public class GetAllUserQueriesRequest:IRequest<GetAllUserQueriesResponse>
    {
        public int page {get; set;}=0;
        public int size {get; set;}=5;
    }
}