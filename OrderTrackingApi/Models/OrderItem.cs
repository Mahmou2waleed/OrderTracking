namespace OrderTrackingApi.Models
{
    /// <summary>
    /// Represents an individual item within an order.
    /// </summary>
    public class OrderItem
    {
        /// <summary>Gets or sets the unique identifier of the product.</summary>
        public int ProductId { get; set; }

        /// <summary>Gets or sets the name of the product.</summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>Gets or sets the quantity of the product ordered.</summary>
        public int Quantity { get; set; }

        /// <summary>Gets or sets the unit price of the product.</summary>
        public decimal Price { get; set; }
    }
}