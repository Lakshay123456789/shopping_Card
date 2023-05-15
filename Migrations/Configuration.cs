using shappingCardInMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
namespace shappingCardInMVC.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<shappingCardInMVC.Models.ProductdbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(shappingCardInMVC.Models.ProductdbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if(!context.RoleMasters.Any())
            {
               var list = new List<RoleMaster>
               {
                   new RoleMaster
                   {
                       RollName="Admin"
                   },
                   new RoleMaster
                   {
                       RollName="Customer"
                   }
               };
                context.RoleMasters.AddRange(list);
            }
            if (!context.Users.Any())
            {
                var newUser=new User
                {
                    UserName = "Admin",
                    Email="Admin@gmail.com",
                    Password = "Admin@123",
                    ConfirmPassword="Admin@123",
                    RoleMasterId=1
                };
                context.Users.Add(newUser);
            }
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        CategoryName="Electronics"
                    },
                    new Category
                    {
                        CategoryName="Clothing"
                    },
                    new Category
                    {
                        CategoryName="Jewelry"
                    },
                    new Category
                    {
                        CategoryName="Furniture"
                    },
                    new Category
                    {
                        CategoryName="FootWear"
                    },
                    new Category
                    {
                        CategoryName="Others"
                    }
                   
                };
                context.Categories.AddRange(categories);
            }
            if (!context.Productes.Any())
            {
                var product = new Product
                {
                    ProductName="IPhone",
                    ProductImage="/Images/Apple-iPhone-14-Pro.jpg",
                    ProductPrice=100000.0,
                    ProductQuantity=1,
                    ProductDescription="This is IPhone IOs",
                    CategoryId=1,
                };
                context.Productes.Add(product);
            }
            context.SaveChanges();
            base.Seed(context);
            
        }
    }
}
