using Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
     public class StoreContextSeed
    {
        public static async Task SeedAsync (EshopDb context,ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())   
                {
                    var brandsData = File.
                        ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach(var brand in brands)
                    {
                        context.ProductBrands.Add(brand);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var productTypesData = File.
                        ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);

                    foreach (var type in productTypes)
                    {
                        context.ProductTypes.Add(type);
                    }

                    await context.SaveChangesAsync();
                }


                if (!context.Products.Any())
                {
                    var productData = File.
                        ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, "There was an error during the seeding of data");
            }
        }
    }
}
