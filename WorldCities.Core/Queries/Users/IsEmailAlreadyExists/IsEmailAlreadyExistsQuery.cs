using MediatR;

namespace WorldCities.Core.Queries.Users.IsEmailAlreadyExists
{
    public record IsEmailAlreadyExistsQuery(string Email) : IRequest<bool>;
}
