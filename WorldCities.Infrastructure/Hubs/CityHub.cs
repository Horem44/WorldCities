using Microsoft.AspNetCore.SignalR;

namespace WorldCities.Infrastructure.Hubs
{
    public class CityHub: Hub
    {
        public async Task IncreaseCityLikesCountClient(Guid cityGuid)
        {
            await Clients.All.SendAsync("increaseCityLikesCount", cityGuid);
        }

        public async Task DecreaseCityLikesCountClient(Guid cityGuid)
        {
            await Clients.All.SendAsync("decreaseCityLikesCount", cityGuid);
        }
    }
}
