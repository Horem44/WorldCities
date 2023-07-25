using AutoMapper;
using MediatR;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.CityImages.Models;
using WorldCities.Domain.Entities.Cities;

namespace WorldCities.Core.Queries.CityImages.GetCityImageById
{
    public record GetCityImageByIdQueryHandler(
        ICityImageRepository CityImageRepository,
        IMapper Mapper
    ) : IRequestHandler<GetCityImageByIdQuery, CityImageDto>
    {
        public async Task<CityImageDto> Handle(
            GetCityImageByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            CityImage? image = await CityImageRepository.GetByGuid(
                request.imageId,
                cancellationToken
            );

            if (image == null)
            {
                throw new Exception();
            }

            return Mapper.Map<CityImageDto>(image);
        }
    }
}
