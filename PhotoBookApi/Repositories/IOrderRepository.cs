using System.Threading.Tasks;
using PhotoBookApi.Models;

namespace PhotoBookApi.Repositories
{
    // Repo layer to access DB
    public interface IOrderRepository
    {
        /// This method allow to go to DB using EF and get the data.
        /// All validations should be done in Upper levels, at this time data here should be correct
        Task<Order> GetOrderAsync(string orderId);

        // This method save the data of the order and the details of the order in the DB
        bool SaveOrder(Order order);

        // Checks if an order exist, sometimes update/insert operations take a lot of time
        // Checking if the data already exist based on the key could improve performance
        bool OrderExists(string id);
    }

}