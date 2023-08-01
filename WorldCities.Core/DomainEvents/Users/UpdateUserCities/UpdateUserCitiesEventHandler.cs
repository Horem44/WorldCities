using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Exceptions;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.DomainEvents.Users.UpdateUserCities
{
    public record UpdateUserCitiesEventHandler(
        ICityRepository CityRepository,
        IUserAccessor UserAccessor,
        IUserRepository UserRepository
    ) : INotificationHandler<UpdateUserCitiesEvent>
    {
        public async Task Handle(
            UpdateUserCitiesEvent notification,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser user = await UserAccessor.User();

            City? city = await CityRepository
                .Get(notification.CityId)
                .FirstOrDefaultAsync(cancellationToken);

            if (city == null)
            {
                throw new NotFoundException("City not found");
            }

            user.Cities.Add(city);

            await UserRepository.Update(user);
        }
    }
};
