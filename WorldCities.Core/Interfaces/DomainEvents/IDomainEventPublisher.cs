using MediatR;

namespace WorldCities.Core.Interfaces.DomainEvents
{
    public interface IDomainEventPublisher
    {
        Task PublishAsync(INotification notification, CancellationToken cancellationToken);
    }
}
