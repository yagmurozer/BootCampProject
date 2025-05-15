

using AutoMapper;
using Business.Dtos.Request.BlackLists;
using Business.Dtos.Response.BlackLists;
using Entities;

namespace Business.Profiles.BlackLists;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BlackList, CreateBlackListRequest>().ReverseMap();
        CreateMap<BlackList, CreatedBlackListResponse>().ReverseMap();

        CreateMap<BlackList, UpdateBlackListRequest>().ReverseMap();
        CreateMap<BlackList, UpdatedBlackListResponse>().ReverseMap();

        CreateMap<BlackList, DeleteBlackListRequest>().ReverseMap();
        CreateMap<BlackList, DeletedBlackListResponse>().ReverseMap();

        CreateMap<BlackList, GetBlackListByIdRequest>().ReverseMap();
        CreateMap<BlackList, GetBlackListByIdResponse>().ReverseMap();

        CreateMap<BlackList, GetListBlackListResponse>().ReverseMap();

    }


}
