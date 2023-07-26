using AutoMapper;
using MediatR;
using WorldCities.Core.Events.Cities.CityCreated;
using WorldCities.Core.Events.Users.UpdateUserCities;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Cities.AddCity
{
    public record AddCityCommandHandler(
        ICountryRepository CountryRepository,
        ICityRepository CityRepository,
        IMapper Mapper,
        IMediator Mediator
    ) : IRequestHandler<AddCityCommand, Unit>
    {
        public async Task<Unit> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            City city = await CityRepository.Add(Mapper.Map<City>(request), cancellationToken);

            await Mediator.Publish(
                new CityCreatedEvent(request.Image, city.Id, request.CountryName, request.UserId)
            );

            await Mediator.Publish(new UpdateUserCitiesEvent(request.UserId, city.Id));

            return Unit.Value;
        }
    }
}
