using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreWebApi.Models
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        static StoreDbContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }
    }
}