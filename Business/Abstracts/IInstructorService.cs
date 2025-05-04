
using Core.Business;
using Entities;

namespace Business.Abstracts;

public interface IInstructorService : IBaseService<Instructor>
{
    void Add(Instructor instructor);
    List<Instructor> GetAll();
    Instructor GetByName(string name);
    void Update(Instructor ınstructor);
    void Delete(int id);

}
