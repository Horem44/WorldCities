using System.Net;

namespace WorldCities.Domain.Exceptions
{
    public class BadRequestException : BaseError
    {
        public BadRequestException(string message)
            : base(HttpStatusCode.BadRequest, message) { }
    }
}
