using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.DTOs.Order;
using ETicaretApi.App.Repository.CompletedOrder;
using ETicaretApi.App.Repository.Order;
using ETicaretApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Persistence.Services
{
   public class OrderServices : IOrderService
   {

    readonly private IOrderWriteRepository _orderWriteRepository;
    readonly private IOrderReadRepository _orderReadRepository;
    readonly private ICompletedOrderWriteRepository _completedOrderWriteRepository;
    readonly private  ICompletedOrderReadRepository  _completedOrderReadRepository;
    public OrderServices(IOrderWriteRepository orderWriteRepository ,
                         IOrderReadRepository orderReadRepository,
                        ICompletedOrderWriteRepository completedOrderWriteRepository,
                        ICompletedOrderReadRepository  completedOrderReadRepository )
    {
        _orderWriteRepository=orderWriteRepository;
        _orderReadRepository=orderReadRepository;
        _completedOrderReadRepository=completedOrderReadRepository;
        _completedOrderWriteRepository=completedOrderWriteRepository;
    }

      public async Task<(bool , CompletedOrders)> CompletedOrderAsync(string id)
      {
        Order? order = await   _orderReadRepository.Table.Include(o=>o.Basket)
                                                               .ThenInclude(b=>b.User)
                                                               .FirstOrDefaultAsync(O=>O.id==Guid.Parse(id));

        if(order!=null){
           await  _completedOrderWriteRepository.AddAsync(new (){OrderId=Guid.Parse(id)});

         return  (await _completedOrderWriteRepository.SaveAsync()>0 ,   new  CompletedOrders(){
            To=order.Basket.User.Email,
            OrderCode=order.OrderCode,
            OrderDate=order.CreatedDate,
            UserName=order.Basket.User.UserName,
            UserSurName=order.Basket.User.NameSurname
         });
        }
        return (false , null);
      }

      public async Task CreateOrder(OrderCreate orderCreate)
      {  var orderCode=(new Random().NextDouble()*10000).ToString();
         orderCode= orderCode.Substring( orderCode.IndexOf(",") +1, orderCode.Length-orderCode.IndexOf(",")-1);

         await _orderWriteRepository.AddAsync(new(){
            id=Guid.Parse(orderCreate.BasketId),
            Name= orderCreate.Name,
            Address=orderCreate.Address,
            Description=orderCreate.Description,
            OrderCode=orderCode
         });

         await _orderWriteRepository.SaveAsync();
      }

      public async Task<SingleOrder> GetByIdOrder(string id)
      {
        var data= await _orderReadRepository.Table
                                             .Include(o=>o.Basket)
                                             .ThenInclude(bi=>bi.BasketItems)
                                             .ThenInclude(b=>b.Product)
                                             .FirstOrDefaultAsync(o=>o.id==Guid.Parse(id));



           
           return new(){
                id=data.id.ToString(),
                BasketItems= data.Basket.BasketItems.Select(bi=>new{
                     bi.Product.Name,
                     bi.Product.Price,
                     bi.Quantity
                }),
                Address=data.Address,
                OrderCode=data.OrderCode,
                CreatedDate=data.CreatedDate,
                Description=data.Description,
                

           };

         
      }

      public   async Task<ListOrder>  GetListOrderAsync(int page , int size)
      {
         var query = _orderReadRepository.Table.Include(o => o.Basket)
                      .ThenInclude(b => b.User)
                      .Include(o => o.Basket)
                         .ThenInclude(b => b.BasketItems)
                         .ThenInclude(bi => bi.Product);

            
                           
            var data = query.Skip(page * size).Take(size);   
           var   data2= from Order in data
                   join CompletedOrder in _completedOrderReadRepository.Table
                   on Order.id  equals CompletedOrder.OrderId into   co 
                   from _co in co.DefaultIfEmpty()
                   select new 
                   {    
                      id=  Order.id,
                      CreatedDate=  Order.CreatedDate,
                      Basket=   Order.Basket,
                      OrderCode=Order.OrderCode,
                      Comleted=_co!=null? true :false

                   }; 
                    
            return new()
            {
                TotalOrderCount= await query.CountAsync(),
                Orders=await data2.Select( o=>new{
                     id= o.id,
                     CreatedDate=o.CreatedDate,
                     OrderCode=o.OrderCode,
                     TotalPrice=o.Basket.BasketItems.Sum(bi=>bi.Product.Price*bi.Quantity),
                     UserName=o.Basket.User.UserName,
                     o.Comleted
                }).ToListAsync()
            
            };
      }

    
   }
}