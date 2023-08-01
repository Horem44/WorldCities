using AutoMapper;
using MediatR;
using WorldCities.Core.DomainEvents.Cities.AddCityImageForCreatedCity;
using WorldCities.Core.DomainEvents.Users.UpdateUserCities;
using WorldCities.Core.Interfaces.Events;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Cities.AddCity
{
    public record AddCityCommandHandler(
        ICountryRepository CountryRepository,
        ICityRepository CityRepository,
        IMapper Mapper,
        IEventPublisher DomainEventPublisher
    ) : IRequestHandler<AddCityCommand, Unit>
    {
        public async Task<Unit> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            City city = await CityRepository.Add(Mapper.Map<City>(request), cancellationToken);

            await DomainEventPublisher.PublishAsync(
                new AddCityImageForCreatedCityEvent(request.Image, city.Id),
                cancellationToken
            );

            await DomainEventPublisher.PublishAsync(
                new UpdateUserCitiesEvent(city.Id),
                cancellationToken
            );

            return Unit.Value;
        }
    }
}
