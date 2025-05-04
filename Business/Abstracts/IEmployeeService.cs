
using Core.Business;
using Entities;

namespace Business.Abstracts;

public interface IEmployeeService : IBaseService<Employee>
{
    void Add(Employee employee);
    List<Employee> GetAll();
    Employee GetByName(string name);
    void Update(Employee employee);
    void Delete(int id);
}
