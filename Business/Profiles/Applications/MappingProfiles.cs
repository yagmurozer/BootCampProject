
using AutoMapper;
using Business.Dtos.Request.Applications;
using Business.Dtos.Response.Applications;
using Entities;

namespace Business.Profiles.Applications;

public class MappingProfiles : Profile
{
    public MappingProfiles() 
    {
        CreateMap<Application, CreateApplicationRequest>().ReverseMap();
        CreateMap<Application, CreatedApplicationResponse>().ReverseMap();

        CreateMap<Application, GetListApplicationResponse>().ReverseMap();

        CreateMap<Applicant, UpdateApplicationRequest>().ReverseMap();
        CreateMap<Applicant, UpdatedApplicationResponse>().ReverseMap();

        CreateMap<Applicant, DeleteApplicationRequest>().ReverseMap();
        CreateMap<Applicant, DeletedApplicationResponse>().ReverseMap();

        CreateMap<Applicant, GetApplicationByIdRequest>().ReverseMap();
        CreateMap<Applicant, GetApplicationByIdResponse>().ReverseMap();
    }

}
