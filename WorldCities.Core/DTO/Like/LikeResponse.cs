namespace WorldCities.Core.DTO.Like
{
    public class LikeResponse
    {
        public Guid LikeGuid {  get; set; }
    }

    public static class LikeExtensions
    {
        public static LikeResponse ToLikeResponse(this WorldCities.Core.Domain.Entities.Like like)
        {
            return new LikeResponse()
            {
                LikeGuid = like.Guid
            };
        }
    }
}
