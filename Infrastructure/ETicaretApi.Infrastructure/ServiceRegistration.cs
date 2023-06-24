
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Abstractions.Services.Configurations;
using ETicaretApi.App.Abstractions.Storage;
using ETicaretApi.App.Abstractions.Token;
using ETicaretApi.Infrastructure.Service;
using ETicaretApi.Infrastructure.Service.Storage;
using ETicaretApi.Infrastructure.Service.Storage.Azure;
using ETicaretApi.Infrastructure.Service.Storage.Enum;
using ETicaretApi.Infrastructure.Service.Storage.Local;
using ETicaretApi.Infrastructure.Service.Token;
using ETicaretAPI.Infrastructure.Services.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretApi.Infrastructure
{
    public  static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService ,StorageService>();
            serviceCollection.AddScoped<ITokenHandler , TokenHandler>();
            serviceCollection.AddScoped<IMailService , MailService>();
            serviceCollection.AddScoped<IQRCodeService , QRCodeService>();
            serviceCollection.AddScoped<IApplicationService ,ApplicationService>();

        }
         public static void AddStorage<T>(this IServiceCollection serviceCollection) where T: Storage ,IStorage
         {
            serviceCollection.AddScoped<IStorage , T>();
         }

          public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:

                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
    }
   
    }
    
    
    }


