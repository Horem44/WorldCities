using MediatR;
using WorldCities.Core.Interfaces.DomainEvents;

namespace WorldCities.Infrastructure.Services
{
    public record DomainEventPublisher(IPublisher Publisher) : IDomainEventPublisher
    {
        public Task PublishAsync(INotification notification, CancellationToken cancellationToken) =>
            Publisher.Publish(notification, cancellationToken);
    }
}
