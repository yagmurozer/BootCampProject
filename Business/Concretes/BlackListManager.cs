

using Business.Abstracts;
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

    public void Add(BlackList blackList)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BlackList Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<BlackList> GetAll()
    {
        throw new NotImplementedException();
    }

    public BlackList GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(BlackList blackList)
    {
        throw new NotImplementedException();
    }
}
