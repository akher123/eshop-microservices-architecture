using Ordering.Application.Orders.Queries.GetOrdersByCustomer;
namespace Ordering.API.Endpoints;
public record GetOrderByCustomerResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/customer/{customerId:guid}", async (Guid customerId, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));
            var response = result.Adapt<GetOrderByCustomerResponse>();
            return Results.Ok(response);

        }).WithName("GetOrderByCustomer")
          .Produces<GetOrderByCustomerResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .ProducesProblem(StatusCodes.Status404NotFound)
          .WithSummary("Get Orders by Customer")
          .WithDescription("Get Orders by Customer");

    }
}
