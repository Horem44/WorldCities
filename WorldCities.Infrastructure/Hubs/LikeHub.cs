using Microsoft.AspNetCore.SignalR;
using WorldCities.Domain.Constants;

namespace WorldCities.Infrastructure.Hubs
{
    public class LikeHub : Hub
    {
        public async Task IncreaseCityLikes(Guid id)
        {
            await Clients.All.SendAsync(SignalRLikeMessageConstants.INCREASE_CITY_LIKES, id);
        }

        public async Task DecreaseCityLikes(Guid id)
        {
            await Clients.All.SendAsync(SignalRLikeMessageConstants.DECREASE_CITY_LIKES, id);
        }
    }
}
