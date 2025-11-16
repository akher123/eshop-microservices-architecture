
namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductResponse(bool IsSuccess);
public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Products/{Id:guid}", async (Guid id, ISender sender) =>
        {
            var respons = sender.Send(new DeleteProductCommand(id));
            var result = respons.Adapt<DeleteProductResponse>();
            Results.Ok(result);
        })
          .WithName("DeleteProduct")
          .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .ProducesProblem(StatusCodes.Status204NoContent)
          .WithSummary("Delete Product")
          .WithDescription("Delete Product");
    }
}
