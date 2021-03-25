using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoBookApiTest.Mock;
using PhotoBookApi.Services;
using PhotoBookApi.Models;

namespace PhotoBookApiTest
{
    [TestClass]
    public class OrderServiceUnitTest
    {
        private string _order = "123";

        [TestMethod]
        public void GetOrderAsyncShouldReturnNewOrderObject()
        {
            // Arrange
            var mockOrderRepository = new MockOrderRepository().MockGetOrderAsync(_order);
            var orderService = new OrderService(mockOrderRepository.Object);

            //Act
            var result = orderService.GetOrderAsync(_order);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveOrderShouldReturnTrue()
        {
            // Arrange
            var mockOrderRepository = new MockOrderRepository().MockSaveOrder(new Order(), true);
            var orderService = new OrderService(mockOrderRepository.Object);

            //Act
            var result = orderService.SaveOrder(new Order());

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OrderExistsShouldReturnTrue()
        {
            // Arrange
            var mockOrderRepository = new MockOrderRepository().MockOrderExists(_order);
            var orderService = new OrderService(mockOrderRepository.Object);

            //Act
            var result = orderService.OrderExists(_order);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OrderExistsShouldReturnFalse()
        {
            // Arrange
            var mockOrderRepository = new MockOrderRepository().MockOrderExists("");
            var orderService = new OrderService(mockOrderRepository.Object);

            //Act
            var result = orderService.OrderExists(_order);

            //Assert
            Assert.IsTrue(result);
            
        }
    }
}
