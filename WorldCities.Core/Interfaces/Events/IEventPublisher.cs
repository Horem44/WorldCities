using MediatR;

namespace WorldCities.Core.Interfaces.Events
{
    public interface IEventPublisher
    {
        Task PublishAsync(INotification notification, CancellationToken cancellationToken);
    }
}
