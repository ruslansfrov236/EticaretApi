using ETicaretApi.Persistence.Context;
using ETicaretApi.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence
{
    public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<ETicaretApiDbContext>
    {
        public ETicaretApiDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ETicaretApiDbContext> dbContextOptionsBuilder = new();


            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);

            return new ETicaretApiDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
