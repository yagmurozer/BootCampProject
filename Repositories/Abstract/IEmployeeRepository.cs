using Core.Repositories;
using Entities;
using System.Linq.Expressions;

namespace Repositories.Abstract;

public interface IEmployeeRepository : IRepository<Employee, Guid>
{
    Task<Employee?> GetByIdAsync(Guid id);
    Task<List<Employee>> GetAllAsync();
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Employee employee);
    Task<bool> AnyAsync(Expression<Func<Employee, bool>> predicate);
}
