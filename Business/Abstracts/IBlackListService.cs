
using Core.Business;
using Entities;

namespace Business.Abstracts;

public interface IBlackListService : IBaseService<BlackList>
{
    void Add(BlackList blackList);
    List<BlackList> GetAll();
    BlackList GetByName(string name);
    void Update(BlackList blackList);
    void Delete(int id);
}
