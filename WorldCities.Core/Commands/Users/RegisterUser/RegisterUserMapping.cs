using AutoMapper;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Commands.Users.RegisterUser
{
    public class RegisterUserMapping : Profile
    {
        public RegisterUserMapping()
        {
            CreateMap<RegisterUserCommand, ApplicationUser>()
                .ForMember(z => z.UserName, z => z.MapFrom(x => x.Email))
                .ForMember(z => z.PersonName, z => z.MapFrom(x => x.PersonName))
                .ForMember(z => z.Email, z => z.MapFrom(x => x.Email));
        }
    }
}
