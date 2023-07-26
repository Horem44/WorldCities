using AutoMapper;
using MediatR;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Events.Cities.CityCreated
{
    public record CreateCityImageForCreatedCityEventHandler(
        ICountryRepository CountryRepository,
        ICityImageRepository CityImageRepository,
        IMapper Mapper
    ) : INotificationHandler<CityCreatedEvent>
    {
        public async Task Handle(CityCreatedEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Image == null || notification.Image.Length == 0)
            {
                throw new Exception("Invalid image");
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
