using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities.Cities;
using WorldCities.Domain.Entities.Countries;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Commands.Cities.AddCity
{
    public record AddCityCommandHandler(
        ICountryRepository CountryRepository,
        UserManager<ApplicationUser> UserManager,
        ICityRepository CityRepository,
        IMapper Mapper,
        IMediator Mediator
    ) : IRequestHandler<AddCityCommand, Guid>
    {
        public async Task<Guid> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId == null)
            {
                throw new BadHttpRequestException("Invalid user id");
            }

            var city = Mapper.Map<City>(request);

            Country? existingCountry = await CountryRepository.GetByName(
                city.Name,
                cancellationToken
            );

            if (existingCountry == null)
            {
                Country newCountry = await CountryRepository.Add(
                    new Country() { Name = request.CountryName, Guid = Guid.NewGuid() },
                    cancellationToken
                );

                city.CountryId = newCountry.Guid;
            }
            else
            {
                city.CountryId = existingCountry.Guid;
            }

            await CityRepository.Add(city, cancellationToken);

            city.CityImageGuid = await CityImageAdderService.UploadCityImage(
                request.File,
                city.Guid
            );

            ApplicationUser? user = await UserManager.FindByIdAsync(request.UserId.ToString());

            if (user != null)
            {
                if (user.Cities == null)
                {
                    user.Cities = new List<City> { city };
                }
                else
                {
                    user.Cities.Add(city);
                }

                if (user.Countries == null)
                {
                    user.Countries = new List<Country> { city.Country };
                }
                else
                {
                    user.Countries.Add(city.Country);
                }

                await UserManager.UpdateAsync(user);
            }

            return city.Guid;
        }
    }
}
