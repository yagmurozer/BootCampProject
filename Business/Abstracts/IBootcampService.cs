
using Core.Business;
using Entities;

namespace Business.Abstracts;

public interface IBootcampService : IBaseService<Bootcamp>
{
    void Add(Bootcamp bootcamp);
    List<Bootcamp> GetAll();
    Bootcamp GetByName(string name);
    void Update(Bootcamp bootcamp);
    void Delete(int id);
}
