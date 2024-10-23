using Core.Layer.Models;
using Core.Layer.Order_Aggregate;
using Repository.Layer.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Layer.Data
{
    public static class StoreSeeding
    {
         public async static Task SeedAsync(StoreDbContext storeDbContext)
         {
            
            var BrandsData = File.ReadAllText("../Repository.Layer/Data/DataSeeding/brands.json");
            var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
            if (Brands.Count() > 0)
            {
                if (storeDbContext.productBrands.Count() == 0)
                {
                    foreach (var brand in Brands)
                    {
                        storeDbContext.productBrands.Add(brand);
                    }
                    
                }
            }
            var categoriesData = File.ReadAllText("../Repository.Layer/Data/DataSeeding/categories.json");
            var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
            if (categories.Count() > 0)
            {
                if (storeDbContext.productCategories.Count() == 0)
                {
                    foreach (var cat in categories)
                    {
                        storeDbContext.productCategories.Add(cat);
                    }
                    
                }
            }
            var productsData = File.ReadAllText("../Repository.Layer/Data/DataSeeding/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            if (products.Count() > 0)
            {
                if (storeDbContext.products.Count() == 0)
                {
                    foreach (var product in products)
                    {
                        storeDbContext.products.Add(product);
                    }
                   
                }
            }
            var deliveries = File.ReadAllText("../Repository.Layer/Data/DataSeeding/delivery.json");
            var deliveriesDes = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveries);
            if(deliveriesDes.Count() > 0)
            {
                if(storeDbContext.deliveryMethods.Count() == 0)
                {
                    foreach(var deliver in deliveriesDes)
                    {
                        storeDbContext.deliveryMethods.Add(deliver);
                    }
                }
            }

            await storeDbContext.SaveChangesAsync();
        }
    }
}
