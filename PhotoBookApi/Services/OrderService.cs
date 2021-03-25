
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhotoBookApi.Helper;
using PhotoBookApi.Models;
using PhotoBookApi.Repositories;

namespace PhotoBookApi.Services
{
    // Repo layer to access DB
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        public OrderService (IOrderRepository repo)
        {
            _repo = repo;
        }

        /// This method allow to go to DB using EF and get the data.
        public async Task<Order> GetOrderAsync(string orderId)
        {
            return await _repo.GetOrderAsync(orderId);
        }

        // This method save the data of the order and the details of the order in the DB
        public bool SaveOrder(Order order)
        {
            return _repo.SaveOrder(order);
        }

        // Checks if an order exist
        public bool OrderExists(string id)
        {
            return _repo.OrderExists(id);
        }

    }
}