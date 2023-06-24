using ETicaretApi.Domain.Entity;
using ETicaretApi.Domain.Entity.Common;
using ETicaretApi.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ETicaretApi.Persistence.Context
{
    public class ETicaretApiDbContext:IdentityDbContext<AppUser , AppRole , string>
    {
        public ETicaretApiDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Entity.File> Files {get; set;}
        public DbSet<InvoiceFile> InvoiceFiles {get; set;}
        public DbSet<ProductImage> ProductImages {get; set;}
        public DbSet <Basket>  Baskets {get; set;}
        public DbSet <BasketItem>  BasketItems {get; set;}
        public DbSet <CompletedOrder> CompletedOrders {get; set;} 
        public DbSet <Endpoint> Endpoints {get; set;} 
        public DbSet <Menu> Menus {get; set;} 
           protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasKey(b => b.id);

           builder.Entity<Order>()
                    .HasIndex(o=>o.OrderCode)
                    .IsUnique();
            builder.Entity<Basket>()
                .HasOne(b => b.Orders)
                .WithOne(o => o.Basket)
                .HasForeignKey<Order>(b => b.id);
            builder.Entity<Order>()
                .HasOne(o=>o.CompletedOrders)
                .WithOne(c=>c.Orders)
                .HasForeignKey<CompletedOrder>(c=>c.OrderId);

            base.OnModelCreating(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                                    .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
