# OrderTrackingApi
An in‑memory ASP.NET Core Web API for tracking user orders.

## Prerequisites
- .NET 6 SDK installed
- Visual Studio 2022

## Getting Started
1. Open a terminal or command prompt.
2. Navigate to this folder.
   ```bash
   cd path/to/OrderTrackingApi      
3. dotnet restore
   dotnet build
4. dotnet run

## API Endpoints
| Method | URL                 | What it does                       |
|--------|---------------------|------------------------------------|
| POST   | /api/orders         | Create a new order                 |
| GET    | /api/orders         | List all your orders               |
| GET    | /api/orders/{id}    | Get one order by its ID            |

### Example: Create Order
Request:
curl -X POST https://localhost:5001/api/orders \
  -H "Content-Type: application/json" \
  -d '[{"productId":1,"name":"Widget","price":9.99,"quantity":2}]'

Response:
{
  "orderId": 1,
  "userId": "demo-user",
  "items": [ /* … */ ],
  "total": 19.98,
  "timestamp": "2025-05-06T14:23:00Z",
  "status": "Pending"
}

### Running Tests
cd OrderTrackingApi.Tests
dotnet test
