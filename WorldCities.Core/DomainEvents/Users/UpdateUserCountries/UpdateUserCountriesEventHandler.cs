using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Exceptions;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.DomainEvents.Users.UpdateUserCountries
{
    public record UpdateUserCountriesEventHandler(
        ICountryRepository CountryRepository,
        IUserRepository UserRepository,
        IUserAccessor UserAccessor
    ) : INotificationHandler<UpdateUserCountriesEvent>
    {
        public async Task Handle(
            UpdateUserCountriesEvent notification,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser user = await UserAccessor.User();

            user.Countries.Add(notification.Country);
            await UserRepository.Update(user);

            notification.Country.Users.Add(user);
            await CountryRepository.SaveChanges();
        }
    }
}
