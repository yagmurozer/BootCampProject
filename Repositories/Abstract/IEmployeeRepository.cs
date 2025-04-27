using Core.Repositories;
using Entities;

namespace Repositories.Abstract;

public interface IEmployeeRepository : IRepository<Employee, Guid>
{

}
