using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Abstractions.Services.Configurations;
using ETicaretApi.App.Repository.Endoint;
using ETicaretApi.App.Repository.Menu;
using ETicaretApi.Domain.Entity;
using ETicaretApi.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Infrastructure.Service
{
   public class AuthorizationEndpointService : IAuthorizationEndpointService
   {

       readonly private IApplicationService _applicationService;
       readonly private IEndpointReadRepository _endpointReadRepository;
       readonly private IEndpointWriteRepository _endpointWriteRepository;
       readonly private IMenuReadRepository  _menuReadRepository;
       readonly private IMenuWriteRepository _menuWriteRepository;
       readonly private RoleManager<AppRole> _roleManager;
       public AuthorizationEndpointService( 
                                             IApplicationService applicationService,
                                             IEndpointReadRepository endpointReadRepository,
                                             IEndpointWriteRepository endpointWriteRepository,
                                             IMenuReadRepository  menuReadRepository,
                                             IMenuWriteRepository menuWriteRepository,
                                             RoleManager<AppRole> roleManager
                                          )
                                  {
                                      _applicationService=applicationService;
                                      _endpointReadRepository=endpointReadRepository;
                                      _endpointWriteRepository=endpointWriteRepository;
                                      _menuReadRepository=menuReadRepository;
                                      _menuWriteRepository=menuWriteRepository;
                                      _roleManager=roleManager;
                                  }
      public async Task<List<string>> GetRolesToEndpointAsync(string code , string menu ){
     Endpoint? endpoint=  await _endpointReadRepository.Table.Include(e=>e.Roles)
                                                             .Include(e=>e.Menu).FirstOrDefaultAsync(e=>e.Code== code && e.Menu.Name==menu);
      if(endpoint!=null)
      endpoint.Roles.Select(r=>r.Name).ToList();
      return null;
  
   }
      public async Task AssignRoleEndpointAsync(string[] roles,string menu,  string code , Type type)
      {  Menu _menu = await _menuReadRepository.GetSingleAsync(m=>m.Name==menu);

        if(_menu==null){
         _menu =new(){
            id=Guid.NewGuid(),
            Name=menu
         };
         await _menuWriteRepository.SaveAsync();
        }
         Endpoint? endpoint=   await  _endpointReadRepository.Table.Include(m=>m.Menu).Include(e=>e.Roles).FirstOrDefaultAsync(e=>e.Code==code && e.Menu.Name==menu);

         if(endpoint==null){
          var action=  _applicationService.GetAuthorizeDefinitionEndpoints(type)
                                            .FirstOrDefault(e=>e.MenuName==menu)
                                            ?.Actions.FirstOrDefault(e=>e.Code==code);

                                            endpoint=new(){
                                                           id=Guid.NewGuid(),
                                                           Code=action.Code,
                                                          ActionType=action.ActionType,
                                                          HttpType=action.HttpType,
                                                          Definition=action.Definition,
                                                          Menu =_menu
                                                          };
               await _endpointWriteRepository.AddAsync(endpoint);
               await  _endpointWriteRepository.SaveAsync();
         }  
         foreach (var role in endpoint.Roles)
         {
            endpoint.Roles.Remove(role);
         }
         var appRoles= await _roleManager.Roles.Where(r=>roles.Contains(r.Name)).ToListAsync();
            foreach (var _role in appRoles)
            {
                endpoint.Roles.Add(_role);
            }
      
              await  _endpointWriteRepository.SaveAsync();
           
      }
   }

 
}