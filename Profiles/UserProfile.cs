using AutoMapper;
using Conduit.DTOs;
using Conduit1.Dtos;
using Conduit1.Models;

namespace Conduit.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() {
            CreateMap<User, UserDto>();
           // CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

        }

    }
}
