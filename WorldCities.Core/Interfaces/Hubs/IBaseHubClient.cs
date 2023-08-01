namespace WorldCities.Core.Interfaces.Hubs
{
    public interface IBaseHubClient<TMessage, TData>
    {
        public Task SendAsync(TMessage message, TData data, CancellationToken cancellationToken);
    }
}
