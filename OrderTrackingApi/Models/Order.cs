namespace OrderTrackingApi.Models
{
    /// <summary>
    /// Represents a customer order.
    /// </summary>
    public class Order
    {
        /// <summary>ID of the order.</summary>
        public int OrderId { get; set; }

        /// <summary>ID of the user.</summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>Gets or sets the list of items included in the order.</summary>
        public List<OrderItem> Items { get; set; } = new();

        /// <summary>Gets or sets the total monetary value of the order.</summary>
        public decimal Total { get; set; }

        /// <summary>Gets or sets the date and time when the order was placed.</summary>
        public DateTime Timestamp { get; set; }

        /// <summary>Gets or sets the current status of the order.</summary>
        /// <remarks>Defaults to "Pending".</remarks>
        public string Status { get; set; } = "Pending";
    }
}