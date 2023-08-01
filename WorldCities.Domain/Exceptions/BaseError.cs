using System.Net;

namespace WorldCities.Domain.Exceptions
{
    public class BaseError : Exception
    {
        public HttpStatusCode Status { get; set; }
        public override string Message { get; }

        public BaseError(HttpStatusCode status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
