
using AutoMapper;
using Business.Dtos.Request.Instructors;
using Business.Dtos.Response.Instructors;
using Entities;


namespace Business.Profiles.Instructors;

public class MappingProfiles : Profile
{
    public MappingProfiles() 
    {
        CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();

        CreateMap<Instructor, GetListInstructorResponse>().ReverseMap();

        CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();

        CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
        CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();

        CreateMap<Instructor, GetInstructorByIdRequest>().ReverseMap();
        CreateMap<Instructor, GetInstructorByIdResponse>().ReverseMap();

    }
}
