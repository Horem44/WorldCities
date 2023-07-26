using AutoMapper;
using MediatR;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public record AddLikeCommandHandler(ILikeRepository LikeRepository, IMapper Mapper)
        : IRequestHandler<AddLikeCommand, Unit>
    {
        public async Task<Unit> Handle(AddLikeCommand request, CancellationToken cancellationToken)
        {
            Like like = Mapper.Map<Like>(request);
            await LikeRepository.Add(like, cancellationToken);

            return Unit.Value;
        }
    }
}
