using System.Collections.Generic;
using OrderTrackingApi.Models;

namespace OrderTrackingApi.Services
{
    /// <summary>
    /// Defines operations for managing customer orders.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Creates a new order for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user placing the order</param>
        /// <param name="items">The collection of items to include in the order</param>
        /// <returns>The newly created <see cref="Order"/> object</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when items list is empty or total amount is negative
        /// </exception>
        Order CreateOrder(string userId, List<OrderItem> items);

        /// <summary>
        /// Retrieves all orders for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user whose orders to retrieve</param>
        /// <returns>A collection of the user's orders</returns>
        IEnumerable<Order> GetOrders(string userId);

        /// <summary>
        /// Retrieves a specific order by its ID for a given user.
        /// </summary>
        /// <param name="userId">The ID of the user who placed the order</param>
        /// <param name="orderId">The ID of the order to retrieve</param>
        /// <returns>The matching order if found, otherwise null</returns>
        Order? GetOrderById(string userId, int orderId);
    }
}