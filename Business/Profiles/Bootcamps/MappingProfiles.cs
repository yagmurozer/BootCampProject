

using AutoMapper;
using Business.Dtos.Request.Bootcamps;
using Business.Dtos.Response.Bootcamps;
using Entities;


namespace Business.Profiles.Bootcamps;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Bootcamp, CreateBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, CreatedBootcampResponse>().ReverseMap();

        CreateMap<Bootcamp, GetListBootcampResponse>().ReverseMap();

        CreateMap<Bootcamp, UpdateBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, UpdatedBootcampResponse>().ReverseMap();

        CreateMap<Bootcamp, DeleteBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, DeletedBootcampResponse>().ReverseMap();

        CreateMap<Bootcamp, GetBootcampByIdRequest>().ReverseMap();
        CreateMap<Bootcamp, GetBootcampByIdResponse>().ReverseMap();
    }
}
