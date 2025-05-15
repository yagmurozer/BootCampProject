
using Business.Dtos.Request.BlackLists;
using Business.Dtos.Response.BlackLists;
using Entities;
namespace Business.Abstracts;

public interface IBlackListService
{
    CreatedBlackListResponse Add(CreateBlackListRequest request);
    List<GetListBlackListResponse> GetList();
    GetBlackListByIdResponse GetById(GetBlackListByIdRequest request);
    UpdatedBlackListResponse Update(UpdateBlackListRequest request);
    DeletedBlackListResponse Delete(DeleteBlackListRequest request);
}
