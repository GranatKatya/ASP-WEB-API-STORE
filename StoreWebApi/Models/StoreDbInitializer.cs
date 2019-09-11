using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreWebApi.Models
{
    public class StoreDbInitializer : DropCreateDatabaseAlways<StoreDbContext>
    {
        protected override void Seed(StoreDbContext context)
        {
            context.Products.Add(new Product {
                Name = "Milk",
                Price = 25.5m
            });
            context.Products.Add(new Product
            {
                Name = "Apple",
                Price = 15.5m
            });
            context.Products.Add(new Product
            {
                Name = "Grapes",
                Price = 50m
            });
            base.Seed(context);
        }
    }
}