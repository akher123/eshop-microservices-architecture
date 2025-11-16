using Microsoft.Extensions.Logging;

namespace Ordering.Application.Orders.EventHandlers;

public class OrderCreaedEventHandler(ILogger<OrderCreaedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Envent Handled: {DomainEvent}", notification);
        return Task.CompletedTask;
    }
}
