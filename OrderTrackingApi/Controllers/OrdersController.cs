using Microsoft.AspNetCore.Mvc;
using OrderTrackingApi.Models;
using OrderTrackingApi.Services;

[ApiController]
[Route("api/[controller]")]
/// <summary>
/// Controller for handling order management operations
/// </summary>
/// <remarks>
/// This controller uses a hardcoded "demo-user" for authentication purposes.
/// In a production system, this would be replaced with proper user authentication.
/// </remarks>
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service) => _service = service;

    /// <summary>
    /// Creates a new order
    /// </summary>
    /// <param name="items">List of items to be ordered</param>
    /// <returns>Newly created order</returns>
    /// <response code="201">Returns the newly created order</response>
    /// <response code="400">If the request contains invalid items</response>
    [HttpPost]
    public IActionResult Create([FromBody] List<OrderItem> items)
    {
        var userId = "demo-user";
        try
        {
            var order = _service.CreateOrder(userId, items);
            return CreatedAtAction(nameof(GetById),
                new { id = order.OrderId }, order);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Gets all orders for the current user
    /// </summary>
    /// <returns>List of user's orders</returns>
    /// <response code="200">Returns all orders for the demo user</response>
    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetOrders("demo-user"));

    /// <summary>
    /// Gets a specific order by ID
    /// </summary>
    /// <param name="id">The ID of the order to retrieve</param>
    /// <returns>Requested order details</returns>
    /// <response code="200">Returns the requested order</response>
    /// <response code="404">If the order cannot be found</response>
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
        => _service.GetOrderById("demo-user", id) is Order o
            ? Ok(o)
            : NotFound(new { error = "Order not found" });
}