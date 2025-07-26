using AutoMapper;
using Business.Dtos.Request.Applicants;
using Business.Dtos.Response.Applicants;
using Entities;


namespace Business.Profiles.Applicants;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // map oluştur CreateMap<TSource, TDestination>
        CreateMap<Applicant, CreateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, CreatedApplicantResponse>().ReverseMap();

        CreateMap<Applicant, GetListApplicantResponse>().ReverseMap();

        CreateMap<Applicant, UpdateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, UpdatedApplicantResponse>().ReverseMap();

        CreateMap<Applicant, DeleteApplicantRequest>().ReverseMap();
        CreateMap<Applicant, DeletedApplicantResponse>().ReverseMap();

        CreateMap<Applicant, GetApplicantByIdRequest>().ReverseMap();
        CreateMap<Applicant, GetApplicantByIdResponse>().ReverseMap();


    }
}
