using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.API.Endpoints;
public record GetOrderResponse(PaginationResult<OrderDto> orders);
public class GetOrders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async ([AsParameters]PaginationRequest request, ISender sender) =>
        {
            var result=sender.Send(new GetOrdersQuery(request));
            var response=result.Adapt<GetOrderResponse>();
            return Results.Ok(response);
        })
          .WithName("GetOrders")
          .Produces<GetOrderResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithSummary("Get Orders")
          .WithDescription("Get Orders");
    }
}
