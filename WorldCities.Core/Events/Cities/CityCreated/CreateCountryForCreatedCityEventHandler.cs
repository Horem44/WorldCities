using AutoMapper;
using MediatR;
using System.Data.Entity;
using WorldCities.Core.Events.Users.UpdateUserCountries;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Events.Cities.CityCreated
{
    public record CreateCountryForCreatedCityEventHandler(
        ICountryRepository CountryRepository,
        ICityImageRepository CityImageRepository,
        IMapper Mapper,
        IMediator Mediator
    ) : INotificationHandler<CityCreatedEvent>
    {
        public async Task Handle(CityCreatedEvent notification, CancellationToken cancellationToken)
        {
            Country? existingCountry = await CountryRepository
                .GetByName(notification.CountryName)
                .FirstOrDefaultAsync(cancellationToken);

            if (existingCountry == null)
            {
                Country addedCountry = await CountryRepository.Add(
                    Mapper.Map<Country>(notification),
                    cancellationToken
                );

                await Mediator.Publish(
                    new UpdateUserCountriesEvent(notification.UserId, addedCountry.Id)
                );
            }
            else
            {
                await Mediator.Publish(
                    new UpdateUserCountriesEvent(notification.UserId, existingCountry.Id)
                );
            }
        }
    }
}
