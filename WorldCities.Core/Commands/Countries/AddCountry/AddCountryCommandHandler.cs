using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.DomainEvents.Users.UpdateUserCountries;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Countries.AddCountry
{
    public record AddCountryCommandHandler(
        ICountryRepository CountryRepository,
        IMediator Mediator,
        IMapper Mapper,
        IHttpContextAccessor httpContextAccessor
    ) : IRequestHandler<AddCountryCommand, Guid>
    {
        public async Task<Guid> Handle(
            AddCountryCommand request,
            CancellationToken cancellationToken
        )
        {
            Country? country = await CountryRepository
                .GetByName(request.CountryName)
                .FirstOrDefaultAsync(cancellationToken);

            if (country == null)
            {
                country = await CountryRepository.Add(
                    Mapper.Map<Country>(request),
                    cancellationToken
                );

                await Mediator.Publish(new UpdateUserCountriesEvent(country));
            }

            return country.Id;
        }
    }
}
