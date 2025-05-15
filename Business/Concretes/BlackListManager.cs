

using Business.Abstracts;
using Business.Dtos.Request.BlackLists;
using Business.Dtos.Response.BlackLists;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class BlackListManager : IBlackListService
{
    private readonly IBlackListRepository blackListRepository;

    public BlackListManager(IBlackListRepository blackListRepository)
    {
        this.blackListRepository = blackListRepository;
    }

    public CreatedBlackListResponse Add(CreateBlackListRequest request)
    {
        throw new NotImplementedException();
    }

    public DeletedBlackListResponse Delete(DeleteBlackListRequest request)
    {
        throw new NotImplementedException();
    }

    public GetBlackListByIdResponse GetById(GetBlackListByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public List<GetListBlackListResponse> GetList()
    {
        throw new NotImplementedException();
    }

    public UpdatedBlackListResponse Update(UpdateBlackListRequest request)
    {
        throw new NotImplementedException();
    }
}
