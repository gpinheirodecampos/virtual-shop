using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.Tests.Database;

public class DatabaseInitializer
{
    public static void Reinitialize(DbContextOptions<AppDbContext> dbContextOptions)
    {
        using var context = new AppDbContext(dbContextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    public static void Initialize(DbContextOptions<AppDbContext> dbContextOptions)
    {
        using var context = new AppDbContext(dbContextOptions);
        context.Database.EnsureCreated();

        if (context.Products.Any())
        {
            return;
        }

        context.Categories.AddRange(new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Category 1"
            },
            new Category
            {
                Id = 2,
                Name = "Category 2"
            },
            new Category
            {
                Id = 3,
                Name = "Category 3"
            }
        });

        context.Products.AddRange(new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Price = 100,
                Description = "Description 1",
                ImageUrl = "https://www.google.com",
                Stock = 10,
                CategoryId = 1
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Price = 200,
                Description = "Description 2",
                ImageUrl = "https://www.google.com",
                Stock = 20,
                CategoryId = 2
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 3",
                Price = 300,
                Description = "Description 3",
                ImageUrl = "https://www.google.com",
                Stock = 30,
                CategoryId = 3
            }
        });

        context.SaveChanges();
    }
}
