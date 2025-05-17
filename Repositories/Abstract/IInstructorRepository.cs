using Core.Repositories;
using Entities;
using System.Linq.Expressions;

namespace Repositories.Abstract;

public interface IInstructorRepository : IRepository<Instructor, Guid>
{
    Task<Instructor?> GetByIdAsync(Guid id);
    Task<List<Instructor>> GetAllAsync();
    Task AddAsync(Instructor instructor);
    Task UpdateAsync(Instructor instructor);
    Task DeleteAsync(Instructor instructor);
    Task<bool> AnyAsync(Expression<Func<Instructor, bool>> predicate);
}
