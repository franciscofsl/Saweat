using MediatR;
using Microsoft.Extensions.Logging;
using Saweat.Domain.Events;

namespace Saweat.Application.Products.Commands.EventHandlers;

public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
{
    private readonly ILogger<ProductCreatedEventHandler> _logger;

    public ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message: "{DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
