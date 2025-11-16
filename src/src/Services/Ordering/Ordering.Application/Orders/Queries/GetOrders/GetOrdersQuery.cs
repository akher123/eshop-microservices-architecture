namespace Ordering.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery(PaginationRequest PaginationRequest):IQuery<GetOrderResult>;

public record GetOrderResult(PaginationResult<OrderDto> Orders);