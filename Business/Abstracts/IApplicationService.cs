
using Core.Business;
using Entities;

namespace Business.Abstracts;

public interface IApplicationService : IBaseService<Application>
{
    void Add(Application application);
    List<Application> GetAll();
    Application GetByName(string name);
    void Update(Application application);
    void Delete(int id);
}
