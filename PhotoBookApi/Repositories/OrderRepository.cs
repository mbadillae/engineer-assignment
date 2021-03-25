
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhotoBookApi.Helper;
using PhotoBookApi.Models;

namespace PhotoBookApi.Repositories
{
    // Repo layer to access DB
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository (OrderContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// This method allow to go to DB using EF and get the data.
        /// All validations should be done in Upper levels, at this time data here should be correct
        public async Task<Order> GetOrderAsync(string orderId)
        {
            var productTypeHelper = new ProductType();
            var orders = await _context.Orders
                 .Include(u => u.Items)
                 .ToArrayAsync();
 
            var response = orders.Where(p => p.OrderId.Equals(orderId)).Select(u => new Order
            {
                OrderId = u.OrderId,
                RequiredBinWidth = u.Items.Sum(p => productTypeHelper.PackageWidth(p.ProductType, p.Quantity)),
                Items = u.Items.Select(p => new Item{ItemId = p.ItemId, OrderId = p.OrderId, ProductType = p.ProductType, Quantity = p.Quantity}).ToList()
            });
            if ((response == null) || (response.Count() == 0))
            {
                return new Order();
            }
            return (Order)response.ElementAt(0);
        }

        // This method save the data of the order and the details of the order in the DB
        public bool SaveOrder(Order order)
        {
            // This can change to be a more complex object and return more data about errors.
            var operationResult = false;

            _context.Orders.Add(order);
            _context.SaveChanges();

            return operationResult;
        }

        // Checks if an order exist, sometimes update/insert operations take a lot of time
        // Checking if the data already exist based on the key could improve performance
        public bool OrderExists(string id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }

    }
}