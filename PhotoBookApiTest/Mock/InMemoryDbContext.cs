using Microsoft.EntityFrameworkCore;
using PhotoBookApi.Models;
using PhotoBookApi.Repositories;
using PhotoBookApi.Helper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;

namespace PhotoBookApiTest.Mock
{
    public class InMemoryDbContext
    {
        private string _orderId = "et001";
        public DbContextOptions<OrderContext> LoadTestData()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: "TestOrderDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new OrderContext(options))
            {
                //workaround to avoid insert duplicate record because we are not deleting this DB
                if(context.Orders.Any(e => e.OrderId == _orderId))
                {
                    var newItem = new Item {ItemId = 1, OrderId = _orderId, ProductType = ProductType.ProductTypeEnum.photoBook, Quantity = 1};
                    var newOrder = new Order { OrderId = _orderId, Items = new List<Item>(){newItem}}; //newOrder.Items.Add(newItem);
                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                }                
            }
            return options;
        }
    }

}