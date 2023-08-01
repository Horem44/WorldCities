using System.Net;

namespace WorldCities.Domain.Exceptions
{
    public class NotFoundException : BaseError
    {
        public NotFoundException(string message)
            : base(HttpStatusCode.NotFound, message) { }
    }
}
