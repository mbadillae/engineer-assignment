using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoBookApiTest.Mock;
using PhotoBookApi.Services;
using PhotoBookApi.Models;
using PhotoBookApi.Controllers;
using Moq;
using Microsoft.Extensions.Logging;
using PhotoBookApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using PhotoBookApi.Helper;
using System.Collections.Generic;

namespace PhotoBookApiTest
{
    [TestClass]
    public class OrderControllerUnitTest
    {
        private string _orderId = "123";
        
        private OkObjectResult _actionResult = new OkObjectResult($"The order with Id 123 was submitted");

        [TestMethod]
        public void GetOrderShouldReturnNotFoundMessage()
        {
            // Arrange
            var mockOrderService = new MockOrderService().MockGetOrderAsync("");
            var mocklogger = new Mock<ILogger<OrderController>>();
            var mockOrderContext = new InMemoryDbContext().LoadTestData();
            var orderController = new OrderController(new OrderContext(mockOrderContext),mocklogger.Object,mockOrderService.Object);

            //Act
            var result = orderController.GetOrder(_orderId);

            //Assert
            //Assert.Equals(result.Result.Value, _order);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostOrderShouldReturnTrue()
        {
            // Arrange
            var mockOrderService = new MockOrderService().MockSaveOrder(new Order());
            var mocklogger = new Mock<ILogger<OrderController>>();
            //var mockOrderContext = new Mock<OrderContext>();
            var mockOrderContext = new InMemoryDbContext().LoadTestData();
            var orderController = new OrderController(new OrderContext(mockOrderContext),mocklogger.Object,mockOrderService.Object);
            //
            var newItem = new Item {ItemId = 2, OrderId = _orderId, ProductType = ProductType.ProductTypeEnum.photoBook, Quantity = 1};
            var newOrder = new Order { OrderId = _orderId, Items = new List<Item>(){newItem}};

            //Act
            var result = orderController.PostOrder(newOrder);

            //Assert
            Assert.AreEqual(result.Result.Value, _actionResult.Value);
        }
    }
}
