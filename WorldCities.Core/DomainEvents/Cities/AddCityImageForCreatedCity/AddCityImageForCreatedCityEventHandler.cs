using AutoMapper;
using MediatR;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Exceptions;

namespace WorldCities.Core.DomainEvents.Cities.AddCityImageForCreatedCity
{
    public record AddCityImageForCreatedCityEventHandler(
        ICityImageRepository CityImageRepository,
        IMapper Mapper
    ) : INotificationHandler<AddCityImageForCreatedCityEvent>
    {
        public async Task Handle(
            AddCityImageForCreatedCityEvent notification,
            CancellationToken cancellationToken
        )
        {
            if (notification.Image == null || notification.Image.Length == 0)
            {
                throw new BadRequestException("Invalid image");
            }

            CityImage imageEntity = Mapper.Map<CityImage>(notification);

            using (var memoryStream = new MemoryStream())
            {
                await notification.Image.CopyToAsync(memoryStream);
                imageEntity.FileData = memoryStream.ToArray();
            }

            await CityImageRepository.Add(imageEntity, cancellationToken);
        }
    }
}
