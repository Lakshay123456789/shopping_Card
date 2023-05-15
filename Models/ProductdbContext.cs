using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shappingCardInMVC.Models
{
    public class ProductdbContext:DbContext
    {
        public ProductdbContext():base() {

        }
         public DbSet<RoleMaster> RoleMasters { get; set; }
          
         public DbSet<User> Users { get; set; }

         public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Productes { get; set; }
    }
}