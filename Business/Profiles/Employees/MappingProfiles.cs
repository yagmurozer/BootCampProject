

using AutoMapper;
using Business.Dtos.Request.Applications;
using Business.Dtos.Request.Employees;
using Business.Dtos.Response.Applications;
using Business.Dtos.Response.Employees;
using Entities;

namespace Business.Profiles.Employees;

public class MappingProfiles : Profile
{
    public MappingProfiles() 
    {
        CreateMap<Employee, CreateApplicationRequest>().ReverseMap();
        CreateMap<Employee, CreatedApplicationResponse>().ReverseMap();

        CreateMap<Employee, GetListApplicationResponse>().ReverseMap();

        CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();
        CreateMap<Employee, UpdatedEmployeeResponse>().ReverseMap();

        CreateMap<Employee, DeleteEmployeeRequest>().ReverseMap();
        CreateMap<Employee, DeletedEmployeeResponse>().ReverseMap();

        CreateMap<Employee, GetEmployeeByIdRequest>().ReverseMap();
        CreateMap<Employee, GetEmployeeByIdResponse>().ReverseMap();

    }
}
