using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Net;
using System.Net.Mail;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.LikeRepositoryContract;
using WorldCities.Core.DTO.Like;
using WorldCities.Core.ServiceContracts.Like;

namespace WorldCities.Core.Services.LikeService
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<LikeResponse> AddLike(Guid userGuid, Guid cityGuid)
        {
            Like like = new Like() { CityGuid = cityGuid, UserGuid = userGuid };
            await _likeRepository.add(like);
            return like.ToLikeResponse();
        }

        public async Task<bool> IsAlreadyExists(Guid userGuid, Guid cityGuid)
        {
            Like existingLike = await _likeRepository.GetByUserCityGuid(userGuid, cityGuid);
            return existingLike == null ? false : true;
        }

        public async Task RemoveLike(Guid userGuid, Guid cityGuid)
        {
            Like likeToDelete = await _likeRepository.GetByUserCityGuid(userGuid, cityGuid);
            await _likeRepository.delete(likeToDelete);
        }
    }
}
