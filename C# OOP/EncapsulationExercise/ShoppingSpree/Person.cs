using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private double money;
        private string name;
        private List<Product> products;

        public IReadOnlyList<Product> Products
        {
            get
            {
                return this.products.AsReadOnly();
            }
        }
        public double Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }

                name = value;
            }
        }

        public Person(string name, int money)
        {
            Money = money;
            Name = name;
            products = new List<Product>();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Name} - ");
            if (products.Count > 0)
            {
                sb.Append(string.Join(", ", products));
            }
            else
            {
                sb.Append("Nothing bought");
            }

            return sb.ToString();
        }

        public void AddProduct(Person person, Product product)
        {
            if (person.Money >= product.Cost)
            {
                person.products.Add(product);
                person.Money -= product.Cost;
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
        }
    }
}
