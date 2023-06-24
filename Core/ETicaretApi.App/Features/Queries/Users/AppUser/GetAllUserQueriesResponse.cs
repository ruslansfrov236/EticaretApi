using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Features.Queries.Users.AppUser
{
    public class GetAllUserQueriesResponse
    {
        public object? Users {get; set;}
        public int TotalCount{get;set;}
    }
}