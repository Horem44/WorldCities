using AutoMapper;
using MediatR;
using System.Data.Entity;
using WorldCities.Core.Events.Users.UpdateUserCountries;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Events.Cities.AddCountryForCreatedCity
{
    public record AddCountryForCreatedCityEventHandler(
        ICountryRepository CountryRepository,
        IMapper Mapper,
        IMediator Mediator
    ) : INotificationHandler<AddCountryForCreatedCityEvent>
    {
        public async Task Handle(
            AddCountryForCreatedCityEvent notification,
            CancellationToken cancellationToken
        )
        {
            Country? existingCountry = await CountryRepository
                .GetByName(notification.CountryName)
                .FirstOrDefaultAsync(cancellationToken);

            if (existingCountry == null)
            {
                existingCountry = await CountryRepository.Add(
                    Mapper.Map<Country>(notification),
                    cancellationToken
                );
            }

            await Mediator.Publish(
                new UpdateUserCountriesEvent(notification.UserId, existingCountry.Id)
            );
        }
    }
}
