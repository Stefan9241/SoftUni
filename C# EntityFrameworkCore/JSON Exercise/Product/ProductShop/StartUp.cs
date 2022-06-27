using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var contextDb = new ProductShopContext();
            //contextDb.Database.EnsureDeleted();
            //contextDb.Database.EnsureCreated();

            //var usersJson = File.ReadAllText("../../../Datasets/users.json");
            //var productsJson = File.ReadAllText("../../../Datasets/products.json");
            //var categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //var catsProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //ImportUsers(contextDb, usersJson);
            //ImportProducts(contextDb, productsJson);
            //ImportCategories(contextDb, categoriesJson);
            //var result = ImportCategoryProducts(contextDb, catsProductsJson);

            //Console.WriteLine(result);

            var result = GetUsersWithProducts(contextDb);
            Console.WriteLine(result);
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x=> x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(b => b.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(b => b.BuyerId != null).Count(),
                        products = x.ProductsSold
                        .Where(b=> b.BuyerId != null)
                        .Select(y => new
                        {
                            name = y.Name,
                            price = y.Price
                        })
                    }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var resultJson = JsonConvert.SerializeObject(resultObject,Formatting.Indented, jsonSettings);
            return resultJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Count == 0 ? 0.ToString("F2") : x.CategoryProducts
                    .Average(y => y.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("F2"),
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return result;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(a => a.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Where(p => p.BuyerId != null)
                    .Select(y => new
                    {
                        name = y.Name,
                        price = y.Price,
                        buyerFirstName = y.Buyer.FirstName,
                        buyerLastName = y.Buyer.LastName
                    })
                    .ToArray()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToArray();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);
            return result;
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitialMapper();

            var dtoCatsProducts = JsonConvert.DeserializeObject<IEnumerable<CategoriesProductsModel>>(inputJson);
            var catsProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCatsProducts);

            context.CategoryProducts.AddRange(catsProducts);
            context.SaveChanges();


            return $"Successfully imported {catsProducts.Count()}";

        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitialMapper();
            var dtoCategories = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();
            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitialMapper();
            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        private static void InitialMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitialMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }
    }
}