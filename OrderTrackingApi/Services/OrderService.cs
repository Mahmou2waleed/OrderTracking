using System;
using System.Collections.Generic;
using System.Linq;
using OrderTrackingApi.Models;

namespace OrderTrackingApi.Services
{
    /// <summary>
    /// Provides services for managing customer orders, including creation and retrieval.
    /// </summary>
    public class OrderService : IOrderService
    {
        private static readonly List<Order> _orders = new();
        private static int _nextId = 1;

        /// <summary>
        /// Creates a new order for the specified user with the given items.
        /// </summary>
        /// <param name="userId">The ID of the user placing the order</param>
        /// <param name="items">The list of items to include in the order</param>
        /// <returns>The newly created order</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when items list is empty or total amount is negative
        /// </exception>
        public Order CreateOrder(string userId, List<OrderItem> items)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("Order must have at least one item.");

            var total = items.Sum(i => i.Quantity * i.Price);
            if (total < 0)
                throw new ArgumentException("Total cannot be negative.");

            var order = new Order
            {
                OrderId = _nextId++,
                UserId = userId,
                Items = items,
                Total = total,
                Timestamp = DateTime.UtcNow,
                Status = "Pending"
            };
            _orders.Add(order);
            return order;
        }

        /// <summary>
        /// Retrieves all orders for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user whose orders to retrieve</param>
        /// <returns>An enumerable collection of the user's orders</returns>
        public IEnumerable<Order> GetOrders(string userId) =>
            _orders.Where(o => o.UserId == userId);

        /// <summary>
        /// Retrieves a specific order by its ID for a given user.
        /// </summary>
        /// <param name="userId">The ID of the user who placed the order</param>
        /// <param name="orderId">The ID of the order to retrieve</param>
        /// <returns>The requested order if found, otherwise null</returns>
        public Order? GetOrderById(string userId, int orderId) =>
            _orders.FirstOrDefault(o => o.UserId == userId && o.OrderId == orderId);
    }
}