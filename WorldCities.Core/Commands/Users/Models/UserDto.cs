namespace WorldCities.Core.Commands.Users.Models
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
