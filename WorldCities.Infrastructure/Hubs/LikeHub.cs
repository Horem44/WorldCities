using Microsoft.AspNetCore.SignalR;
using WorldCities.Core.Interfaces.Hubs;

namespace WorldCities.Infrastructure.Hubs
{
    public class LikeHub : Hub<ILikeHubClient>
    {
        public LikeHub() { }
    }
}
