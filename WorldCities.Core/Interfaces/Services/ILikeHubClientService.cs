namespace WorldCities.Core.Interfaces.Services
{
    public interface ILikeHubClientService
    {
        Task IncreaseCityLikes(Guid id, CancellationToken cancellationToken);
        Task DecreaseCityLikes(Guid id, CancellationToken cancellationToken);
    }
}
