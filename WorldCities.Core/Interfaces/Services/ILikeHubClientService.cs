namespace WorldCities.Core.Interfaces.Services
{
    public interface ILikeHubClientService
    {
        Task SendMessage(string message, Guid id, CancellationToken cancellationToken);
    }
}
