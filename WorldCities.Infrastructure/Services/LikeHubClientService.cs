using Microsoft.AspNetCore.SignalR;
using WorldCities.Core.Interfaces.Hubs;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Infrastructure.Hubs;

namespace WorldCities.Infrastructure.Services
{
    public record LikeHubClientService(IHubContext<LikeHub, ILikeHubClient> LikeHubContext)
        : ILikeHubClientService
    {
        public Task SendMessage(string message, Guid id, CancellationToken cancellationToken)
        {
            return LikeHubContext.Clients.All.SendAsync(message, id, cancellationToken);
        }
    }
}
