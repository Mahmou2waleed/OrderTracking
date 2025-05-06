using OrderTrackingApi.Services;
using System.Reflection;

namespace OrderTrackingApi
{
    /// <summary>
    /// Main entry point for the Order Tracking API application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point that configures and runs the web host
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure application services
            builder.Services.AddSingleton<IOrderService, OrderService>();
            builder.Services.AddControllers();

            // Configure Swagger/OpenAPI documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                // Include XML comments from all documentation files
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                // Enable Swagger UI in development environment
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Tracking API v1");
                });
            }

            // Configure middleware components
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}