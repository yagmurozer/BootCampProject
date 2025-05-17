using Core.Repositories;
using Entities;
using System.Linq.Expressions;

namespace Repositories.Abstract;

public interface IBootcampRepository : IRepository<Bootcamp,Guid>
{
    Task<Bootcamp?> GetByIdAsync(Guid id);
    Task<List<Bootcamp>> GetAllAsync();
    Task AddAsync(Bootcamp bootcamp);
    Task UpdateAsync(Bootcamp bootcamp);
    Task DeleteAsync(Bootcamp bootcamp);
    Task<bool> AnyAsync(Expression<Func<Bootcamp, bool>> predicate);

}
