using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Events.Users.UpdateUserCities
{
    public record UpdateUserCitiesEventHandler(
        ICityRepository CityRepository,
        UserManager<ApplicationUser> UserManager
    ) : INotificationHandler<UpdateUserCitiesEvent>
    {
        public async Task Handle(
            UpdateUserCitiesEvent notification,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser? user = await UserManager.FindByIdAsync(notification.UserId.ToString());

            City? city = await CityRepository
                .Get(notification.CityId)
                .FirstOrDefaultAsync(cancellationToken);

            if (city == null || user == null)
            {
                throw new Exception();
            }

            user.Cities.Add(city);
            await UserManager.UpdateAsync(user);
        }
    }
};
