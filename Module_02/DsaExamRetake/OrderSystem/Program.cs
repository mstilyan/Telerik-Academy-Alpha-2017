using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OrderSystem
{
    class Program
    {
        private const string AddOrderCommand = "AddOrder ";
        private const string FindOrderByConsumerCommand = "FindOrdersByConsumer ";
        private const string DeleteOrdersCommand = "DeleteOrders ";
        private const string FindOrdersByPriceRangeCommand = "FindOrdersByPriceRange ";

        private static IDictionary<string, OrderedBag<Order>> ordersByConsumer;
        private static OrderedBag<Order> ordersByPrice;

        private static OrderComparer orderComparer;
        private static OrderByNameComparer orderByNameComparer;


        static void Main(string[] args)
        {
            orderComparer = new OrderComparer();
            orderByNameComparer = new OrderByNameComparer();

            ordersByConsumer = new Dictionary<string, OrderedBag<Order>>();
            ordersByPrice = new OrderedBag<Order>(orderComparer);

            // ReSharper disable once AssignNullToNotNullAttribute
            var commandsCount = int.Parse(Console.ReadLine());

            var output = ProcessInput(commandsCount);
            Console.WriteLine(output);
        }

        private static string ProcessInput(int commandsCount)
        {
            var resultBuilder = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                var commandLine = Console.ReadLine();
                string commandOuput = String.Empty;

                // ReSharper disable once PossibleNullReferenceException
                if (commandLine.StartsWith(AddOrderCommand))
                {
                    commandOuput = AddOrder(commandLine.Remove(0, AddOrderCommand.Length));
                }
                else if (commandLine.StartsWith(FindOrderByConsumerCommand))
                {
                    commandOuput = FindOrderByConsumer(commandLine.Remove(0, FindOrderByConsumerCommand.Length));
                }
                else if (commandLine.StartsWith(DeleteOrdersCommand))
                {
                    commandOuput = DeleteOrders(commandLine.Remove(0, DeleteOrdersCommand.Length));
                }
                else if (commandLine.StartsWith(FindOrdersByPriceRangeCommand))
                {
                    commandOuput = FindOrdersByPriceRange(commandLine.Remove(0, FindOrdersByPriceRangeCommand.Length));
                }

                resultBuilder.AppendLine(commandOuput);
            }

            return resultBuilder.ToString().TrimEnd();
        }

        private static string FindOrdersByPriceRange(string commandParametersString)
        {
            var commandParameters = commandParametersString
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var fromPrice = decimal.Parse(commandParameters[0]);
            var toPrice = decimal.Parse(commandParameters[1]);

            var fromOrder = new Order { Price = fromPrice - 0.001m};
            var toOrder = new Order { Price = toPrice + 0.001m };

            var range = ordersByPrice.Range(fromOrder, false, toOrder, false);

            if (range.Count == 0)
            {
                return "No orders found";
            }

            return string.Join(Environment.NewLine, range.OrderBy(x => x.Name));
        }

        private static string DeleteOrders(string commandParametersString)
        {
            var consumerName = commandParametersString;

            if (!ordersByConsumer.ContainsKey(consumerName))
            {
                return "No orders found";
            }

            int deletedOrdersCount = ordersByConsumer[consumerName].Count;
            foreach (var order in ordersByConsumer[consumerName])
            {
                ordersByPrice.Remove(order);
            }

            ordersByConsumer.Remove(consumerName);

            return $"{deletedOrdersCount} orders deleted";
        }

        private static string FindOrderByConsumer(string commandParametersString)
        {
            var consumerName = commandParametersString;

            if (!ordersByConsumer.ContainsKey(consumerName))
            {
                return "No orders found";
            }

            return string.Join(Environment.NewLine, ordersByConsumer[consumerName]);
        }

        private static string AddOrder(string commandParametersString)
        {
            var commandParameters = commandParametersString
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var orderName = commandParameters[0];
            var orderPrice = decimal.Parse(commandParameters[1]);
            var orderConsumer = commandParameters[2];

            var order = new Order { Consumer = orderConsumer, Name = orderName, Price = orderPrice };

            if (!ordersByConsumer.ContainsKey(orderConsumer))
            {
                ordersByConsumer.Add(orderConsumer, new OrderedBag<Order>(orderByNameComparer));
            }

            ordersByConsumer[orderConsumer].Add(order);
            ordersByPrice.Add(order);

            return "Order added";
        }
    }

    class Order
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Consumer { get; set; }

        public override string ToString()
        {
            return "{" + $"{this.Name};{this.Consumer};{this.Price:0.00}" + "}";
        }
    }

    class OrderComparer : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            var priceCmp = x.Price.CompareTo(y.Price);
            if (priceCmp != 0) return priceCmp;

            var nameCmp = String.Compare(x.Name, y.Name, StringComparison.Ordinal);
            if (nameCmp != 0) return nameCmp;

            return String.Compare(x.Consumer, y.Consumer, StringComparison.Ordinal);
        }
    }

    class OrderByNameComparer : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            return String.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

}