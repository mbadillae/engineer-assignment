using System.Collections.Generic;
using Moq;
using PhotoBookApi.Models;
using PhotoBookApi.Repositories;
using PhotoBookApi.Services;

namespace PhotoBookApiTest.Mock
{
    // Class to mock repository and test service class
    public class MockOrderService : Mock<IOrderService> { 

         private string _orderId = "123";

        // 
        public MockOrderService MockGetOrderAsync(string orderId)
        {
            Setup(x => x.GetOrderAsync(_orderId))
            .ReturnsAsync(new Order{ OrderId = _orderId, Items = new List<Item>{ new Item{OrderId  = _orderId }} });

            Setup(x => x.GetOrderAsync("")).ReturnsAsync(new Order());

            return this;
        }

        ///Returns the result for save operation
        public MockOrderService MockSaveOrder(Order order)
        {
            Setup(x => x.SaveOrder(It. IsAny<Order>()))
            .Returns(true);

            return this;
        }

        /// Mock result for order exist or not
        public MockOrderService MockOrderExists(string orderId)
        {
            Setup(x => x.OrderExists(""))
            .Returns(false);

            Setup(x => x.OrderExists(_orderId))
            .Returns(true);

            return this;
        }


    }
}
