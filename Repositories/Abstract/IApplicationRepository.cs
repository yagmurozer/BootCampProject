using Core.Repositories;
using Entities;
using System.Linq.Expressions;

namespace Repositories.Abstract;

public interface IApplicationRepository : IRepository<Application,Guid>
{
    Task<Application?> GetByIdAsync(Guid id);
    Task<List<Application>> GetAllAsync();
    Task AddAsync(Application application);
    Task UpdateAsync(Application application);
    Task DeleteAsync(Application application);
    Task<bool> AnyAsync(Expression<Func<Application, bool>> predicate);

}
