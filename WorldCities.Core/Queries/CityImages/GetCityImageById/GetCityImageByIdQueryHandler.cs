using AutoMapper;
using MediatR;
using System.Data.Entity;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Exceptions;

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
            CityImage? image = await CityImageRepository
                .Get(request.imageId)
                .FirstOrDefaultAsync(cancellationToken);

            if (image == null)
            {
                throw new NotFoundException("City image not found");
            }

            return Mapper.Map<CityImageDto>(image);
        }
    }
}
