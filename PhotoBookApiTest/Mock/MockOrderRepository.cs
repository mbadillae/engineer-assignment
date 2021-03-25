using System.Collections.Generic;
using Moq;
using PhotoBookApi.Models;
using PhotoBookApi.Repositories;

namespace PhotoBookApiTest.Mock
{
    // Class to mock repository and test service class
    public class MockOrderRepository : Mock<IOrderRepository> { 

         private string _orderId = "123";

        // 
        public MockOrderRepository MockGetOrderAsync(string orderId)
        {
            Setup(x => x.GetOrderAsync(It.IsAny<string>()))
            .ReturnsAsync(new Order{ OrderId = _orderId, Items = new List<Item>{ new Item{OrderId  = _orderId }} });

            return this;
        }

        ///Returns the result for save operation
        public MockOrderRepository MockSaveOrder(Order order, bool result)
        {
            Setup(x => x.SaveOrder(It. IsAny<Order>()))
            .Returns(result);

            return this;
        }

        /// Mock result for order exist or not
        public MockOrderRepository MockOrderExists(string orderId)
        {
            Setup(x => x.OrderExists(""))
            .Returns(false);

            Setup(x => x.OrderExists(_orderId))
            .Returns(true);

            return this;
        }


    }
}
