using System.Net;

namespace WorldCities.Domain.Exceptions
{
    public class UnauthorizedException : BaseError
    {
        public UnauthorizedException(string message)
            : base(HttpStatusCode.Unauthorized, message) { }
    }
}
