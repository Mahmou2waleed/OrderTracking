using System;
using System.Collections.Generic;
using Xunit;
using OrderTrackingApi.Models;
using OrderTrackingApi.Services;

namespace OrderTrackingApi.Tests
{
    public class OrderServiceTests
    {
        private readonly OrderService _service = new OrderService();

        [Fact]
        public void CreateOrder_ValidItems_ReturnsCorrectTotalAndId()
        {
            // Arrange
            var items = new List<OrderItem> {
                new() { ProductId = 1, ProductName = "A", Price = 5m, Quantity = 2 },
                new() { ProductId = 2, ProductName = "B", Price = 3m, Quantity = 1 }
            };

            // Act
            var order = _service.CreateOrder("user123", items);

            // Assert
            Assert.Equal(13m, order.Total);
            Assert.Equal(1, order.OrderId);
            Assert.Equal("user123", order.UserId);
        }

        [Fact]
        public void CreateOrder_NoItems_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() =>
                _service.CreateOrder("user123", new List<OrderItem>()));
        }

        [Fact]
        public void GetOrderById_Nonexistent_ReturnsNull()
        {
            var result = _service.GetOrderById("user123", 999);
            Assert.Null(result);
        }

    }
}
