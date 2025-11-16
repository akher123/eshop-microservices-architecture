
namespace Basket.API.Basket.GetBasket;
public record GetBasketQuery(string userName):IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);
public class GetBasketQueryHandler (IBasketRepository repository): IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        return new GetBasketResult(await repository.GetBasketAsync(query.userName, cancellationToken)); 
    }
}
