using MediatR;
using WorldCities.Core.Interfaces.Events;

namespace WorldCities.Infrastructure.Services
{
    public record EventPublisher(IPublisher Publisher) : IEventPublisher
    {
        public Task PublishAsync(INotification notification, CancellationToken cancellationToken) =>
            Publisher.Publish(notification, cancellationToken);
    }
}
