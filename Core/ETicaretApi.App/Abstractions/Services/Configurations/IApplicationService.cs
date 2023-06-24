using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.DTOs.Configuration;

namespace ETicaretApi.App.Abstractions.Services.Configurations
{
    public interface IApplicationService
    {
            List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
    }
}