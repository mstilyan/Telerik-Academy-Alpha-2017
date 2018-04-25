using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket
{
    class Program
    {
        private static readonly HashSet<Product> products = new HashSet<Product>();

        private static readonly Dictionary<string, SortedSet<Product>> orderedByType =
            new Dictionary<string, SortedSet<Product>>();

        private static readonly SortedSet<Product> orderedByPrice =
            new SortedSet<Product>();

        static void Main(string[] args)
        {
            var resultBuilder = new StringBuilder();
            ProcessCommands(resultBuilder);
            Console.Write(resultBuilder);
        }

        private static void ProcessCommands(StringBuilder resultBuilder)
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var commandArgs = input.Split();
                switch (commandArgs[0])
                {
                    case "add":
                        AddProduct(commandArgs, resultBuilder);
                        break;
                    case "filter":
                        if (commandArgs[2] == "type") FilterByType(resultBuilder, commandArgs);
                        else if (commandArgs[2] == "price") FilterByPrice(resultBuilder, commandArgs);
                        break;
                }
            }
        }

        private static void FilterByPrice(StringBuilder resultBuilder, string[] commandArgs)
        {
            decimal from = 0;
            decimal to = decimal.MaxValue;

            switch (commandArgs.Length)
            {
                case 7:
                    from = decimal.Parse(commandArgs[4]);
                    to = decimal.Parse(commandArgs[6]);
                    break;
                case 5:
                    if (commandArgs[3] == "from")
                        from = decimal.Parse(commandArgs[4]);
                    else if (commandArgs[3] == "to")
                        to = decimal.Parse(commandArgs[4]);
                    break;
            }

            var productsOrderedByPrice = orderedByPrice.Where(x => x.Price >= from && x.Price <= to).Take(10);
            resultBuilder.Append($"Ok: {string.Join(", ", productsOrderedByPrice)}\n");
        }

        private static void FilterByType(StringBuilder resultBuilder, string[] commandArgs)
        {
            string type = commandArgs[3];

            if (!orderedByType.ContainsKey(type))
            {
                resultBuilder.Append($"Error: Type {type} does not exists\n");
                return;
            }

            resultBuilder.Append($"Ok: {string.Join(", ", orderedByType[type])}\n");
        }

        private static void AddProduct(string[] commandArgs, StringBuilder resultBuilder)
        {
            var name = commandArgs[1];
            var price = decimal.Parse(commandArgs[2]);
            var type = commandArgs[3];

            var newProduct = new Product(name, price, type);

            if (products.Contains(newProduct))
            {
                resultBuilder.Append($"Error: Product {name} already exists\n");
                return;
            }

            products.Add(newProduct);

            if (!orderedByType.ContainsKey(type))
            {
                orderedByType[type] = new SortedSet<Product>();
            }

            if (orderedByType[type].Count == 10)
            {
                var max = orderedByType[type].Max;
                if (max.CompareTo(newProduct) > 0)
                {
                    orderedByType[type].Remove(max);
                    orderedByType[type].Add(newProduct);
                }
            }
            else
            {
                orderedByType[type].Add(newProduct);
            }

            orderedByPrice.Add(newProduct);
            resultBuilder.Append($"Ok: Product {name} added successfully\n");
        }
    }

    internal class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public Product(string name, decimal price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
        }

        public int CompareTo(Product other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var priceComparison = Price.CompareTo(other.Price);
            if (priceComparison != 0) return priceComparison;

            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;

            return string.Compare(Type, other.Type, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return $"{Name}({Price:G29})";
        }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null && this.Name.Equals(product.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
