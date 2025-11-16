
namespace Catalog.API.Products.GetProductsByCatagory;

public record GetProductsByCatagoryResponse(IEnumerable<Product> Products);

public class GetProductsByCatagoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/catagory/{catagroy}", async (string catagroy, ISender sender) => {
            var result = await sender.Send(new GetProductsByCatagoryQuery(catagroy));
            var response = result.Adapt<GetProductsByCatagoryResponse>();
            return Results.Ok(response);

        }).WithName("GetProductsByCatagory")
        .Produces<GetProductsByCatagoryResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Proucts by Catagory")
        .WithDescription("Retrieves a list of products by catagory.");
    }
}
