
namespace Catalog.API.Products.GetProductsByCatagory;

public record GetProductsByCatagoryQuery(string Catagory) : IQuery<GetProductsByCatagoryResult>;
public record GetProductsByCatagoryResult(IEnumerable<Product> Products);

public class GetProductsByCatagoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsByCatagoryQuery, GetProductsByCatagoryResult>
{
    public async Task<GetProductsByCatagoryResult> Handle(GetProductsByCatagoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
               .Where(x => x.Category.Contains(query.Catagory)).ToListAsync(cancellationToken);

        return new GetProductsByCatagoryResult(products);
    }
}
