using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var partJson = File.ReadAllText("../../../Datasets/parts.json");
            //var carJson = File.ReadAllText("../../../Datasets/cars.json");
            //var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //var salesJson = File.ReadAllText("../../../Datasets/sales.json");
            //ImportSuppliers(context, suppJson);
            //ImportParts(context, partJson);
            //ImportCars(context, carJson);
            //ImportCustomers(context, customersJson);
            //Console.WriteLine(ImportSales(context, salesJson));

            Console.WriteLine(GetOrderedCustomers(context));
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => !x.IsYoungDriver)
                .Select(x => new
                {
                    name = x.Name,
                    birthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    isYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return result;
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDto = JsonConvert.DeserializeObject<IEnumerable<SalesInputModel>>(inputJson);
            var sales = salesDto
                .ToList()
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    Discount = x.Discount,
                    CustomerId = x.CustomerId
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDtos = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);
            var customers = customersDtos
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();


            return $"Successfully imported {customers.Count()}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert
                .DeserializeObject<IEnumerable<CarInputModel>>(inputJson);
            var listOdCars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                listOdCars.Add(currCar);
            }
            context.Cars.AddRange(listOdCars);
            context.SaveChanges();

            return $"Successfully imported {listOdCars.Count()}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliedIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            var parts = JsonConvert
                .DeserializeObject<IEnumerable<Part>>(inputJson)
                .Where(s => suppliedIds.Contains(s.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var supplierDtos = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierInputModel>>(inputJson);
            var suppliers = supplierDtos
                .Select(x => new Supplier
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }
    }
}