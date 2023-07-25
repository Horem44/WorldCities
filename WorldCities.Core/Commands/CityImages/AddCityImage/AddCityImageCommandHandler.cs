using MediatR;
using Microsoft.AspNetCore.Http;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities.Cities;

namespace WorldCities.Core.Commands.CityImages.AddCityImage
{
    public record AddCityImageCommandHandler(ICityImageRepository CityImageRepository)
        : IRequestHandler<AddCityImageCommand, Guid>
    {
        public async Task<Guid> Handle(
            AddCityImageCommand request,
            CancellationToken cancellationToken
        )
        {
            if (request.image == null || request.image.Length == 0)
            {
                throw new BadHttpRequestException("Invalid image");
            }

            CityImage imageEntity = new CityImage()
            {
                CityGuid = request.cityId,
                FileName = request.image.FileName,
                ContentType = request.image.ContentType
            };

            using (var memoryStream = new MemoryStream())
            {
                await request.image.CopyToAsync(memoryStream);
                imageEntity.FileData = memoryStream.ToArray();
            }

            await CityImageRepository.Add(imageEntity, cancellationToken);

            return imageEntity.Guid;
        }
    }
}
