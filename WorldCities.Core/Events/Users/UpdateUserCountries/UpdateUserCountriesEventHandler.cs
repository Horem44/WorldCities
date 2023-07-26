using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Events.Users.UpdateUserCountries
{
    public record UpdateUserCountriesEventHandler(
        ICountryRepository CountryRepository,
        UserManager<ApplicationUser> UserManager
    ) : INotificationHandler<UpdateUserCountriesEvent>
    {
        public async Task Handle(
            UpdateUserCountriesEvent notification,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser? user = await UserManager.FindByIdAsync(notification.UserId.ToString());

            Country? country = await CountryRepository
                .Get(notification.CountryId)
                .FirstOrDefaultAsync(cancellationToken);

            if (country == null || user == null)
            {
                throw new Exception();
            }

            user.Countries.Add(country);
            await UserManager.UpdateAsync(user);
        }
    }
}
