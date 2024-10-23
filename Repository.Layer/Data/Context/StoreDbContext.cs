using Core.Layer.Models;
using Core.Layer.Order_Aggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Data.Context
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<DeliveryMethod> deliveryMethods { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> ordersItem { get; set; }    
    }
}
