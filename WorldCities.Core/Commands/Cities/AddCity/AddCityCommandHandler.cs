using AutoMapper;
using MediatR;
using WorldCities.Core.Events.Cities.AddCityImageForCreatedCity;
using WorldCities.Core.Events.Cities.AddCountryForCreatedCity;
using WorldCities.Core.Events.Users.UpdateUserCities;
using WorldCities.Core.Interfaces.DomainEvents;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Cities.AddCity
{
    public record AddCityCommandHandler(
        ICountryRepository CountryRepository,
        ICityRepository CityRepository,
        IMapper Mapper,
        IDomainEventPublisher DomainEventPublisher
    ) : IRequestHandler<AddCityCommand, Unit>
    {
        public async Task<Unit> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            City city = await CityRepository.Add(Mapper.Map<City>(request), cancellationToken);

            await DomainEventPublisher.PublishAsync(
                new AddCountryForCreatedCityEvent(request.CountryName, request.UserId),
                cancellationToken
            );

            await DomainEventPublisher.PublishAsync(
                new AddCityImageForCreatedCityEvent(request.Image, city.Id),
                cancellationToken
            );

            await DomainEventPublisher.PublishAsync(
                new UpdateUserCitiesEvent(request.UserId, city.Id),
                cancellationToken
            );

            return Unit.Value;
        }
    }
}
