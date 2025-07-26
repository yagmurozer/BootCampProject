using AutoMapper;
using Business.Dtos.Request.User;
using Business.Dtos.Response.User;
using Core.Security.Entites;
using Entities;

namespace Business.Profiles.Users
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, CreatedUserResponse>().ReverseMap();

            CreateMap<User, GetListUserResponse>().ReverseMap();

            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, UpdatedUserResponse>().ReverseMap();

            CreateMap<User, DeleteUserRequest>().ReverseMap();
            CreateMap<User, DeletedUserResponse>().ReverseMap();

            CreateMap<User, GetUserByIdRequest>().ReverseMap();
            CreateMap<User, GetUserByIdResponse>().ReverseMap();
        }

    }
}
