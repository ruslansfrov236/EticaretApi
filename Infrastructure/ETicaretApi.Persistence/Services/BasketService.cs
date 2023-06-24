using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Repository.Basket;
using ETicaretApi.App.Repository.BasketItem;
using ETicaretApi.App.Repository.Order;
using ETicaretApi.App.ViewModels.Baskets;
using ETicaretApi.Domain.Entity;
using ETicaretApi.Domain.Entity.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Persistence.Services
{
   public class BasketService : IBasketService
   {

       readonly  private IHttpContextAccessor _httpContextAccessor;
       readonly private UserManager<AppUser>  _userManager;
       readonly private IOrderReadRepository  _orderReadRepository;
       readonly  private IBasketReadRepository  _basketReadRepository;
       readonly  private IBasketItemReadRepository  _basketItemReadRepository;
       readonly  private IBasketWriteRepository  _basketWriteRepository;
       readonly  private IBasketItemWriteRepository  _basketItemWriteRepository;

       public BasketService( IHttpContextAccessor httpContextAccessor,
    UserManager<AppUser> userManager,
    IOrderReadRepository orderReadRepository,
    IBasketReadRepository basketReadRepository,
    IBasketWriteRepository basketWriteRepository,
    IBasketItemWriteRepository basketItemWriteRepository,
    IBasketItemReadRepository basketItemReadRepository)
       {
    _httpContextAccessor = httpContextAccessor;
    _userManager = userManager;
    _orderReadRepository = orderReadRepository;
    _basketReadRepository = basketReadRepository;
    _basketWriteRepository = basketWriteRepository;
    _basketItemWriteRepository = basketItemWriteRepository;
    _basketItemReadRepository = basketItemReadRepository;
       }

       private async Task<Basket?> ContextUser()
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users
                         .Include(u => u.Baskets)
                         .FirstOrDefaultAsync(u => u.UserName == username);

                var _basket = from basket in user.Baskets
                              join order in _orderReadRepository.Table
                              on basket.id equals order.id into BasketOrders
                              from order in BasketOrders.DefaultIfEmpty()
                              select new
                              {
                                  Basket = basket,
                                  Order = order
                              };

                Basket? targetBasket = null;
                if (_basket.Any(b => b.Order is null))
                    targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
                else
                {
                    targetBasket = new();
                    user.Baskets.Add(targetBasket);
                }

                await _basketWriteRepository.SaveAsync();
                return targetBasket;
            }
            throw new Exception("Beklenmeyen bir hatayla karşılaşıldı...");
        }

        public async Task AddItemToBasketAsync(VM_BasketItemCreate basketItem)
        {
            Basket? basket = await ContextUser();
            if (basket != null)
            {
                BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(bi => bi.BasketId == basket.id && bi.ProductId == Guid.Parse(basketItem.ProductId));
                if (_basketItem != null)
                    _basketItem.Quantity++;
                else
                    await _basketItemWriteRepository.AddAsync(new()
                    {
                        BasketId = basket.id,
                        ProductId = Guid.Parse(basketItem.ProductId),
                        Quantity = basketItem.Quantity
                    });

                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket? basket = await ContextUser();
            Basket? result = await _basketReadRepository.Table
                 .Include(b => b.BasketItems)
                 .ThenInclude(bi => bi.Product)
                 .FirstOrDefaultAsync(b => b.id == basket.id);

            return result.BasketItems
                .ToList();
        }

        public async Task RemoveBasketItemAsync(string basketItemId)
        {
            BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
            if (basketItem != null)
            {
                _basketItemWriteRepository.Remove(basketItem);
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public async Task UpdateQuantityAsync(VM_BasketItemUpdate basketItem)
        {
            BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId);
            if (_basketItem != null)
            {
                _basketItem.Quantity = basketItem.Quantity;
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public Basket? GetUserActiveBasket
        {
            get
            {
                Basket? basket = ContextUser().Result;
                return basket;
            }
        }
    }
}