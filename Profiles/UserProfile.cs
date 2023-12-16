using AutoMapper;
using IdentityGuard.Data.DTO.User;
using IdentityGuard.Models;

namespace IdentityGuard.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
        }
    }
}
