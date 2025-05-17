using Core.Repositories;
using Entities;
using System.Linq.Expressions;

namespace Repositories.Abstract;

public interface IApplicantRepository : IRepository<Applicant,Guid>
{
    Task<Applicant?> GetByIdAsync(Guid id);
    Task<bool> AnyAsync(Expression<Func<Applicant, bool>> predicate);
    Task<List<Applicant>> GetAllAsync();
    Task AddAsync(Applicant applicant);
    Task UpdateAsync(Applicant applicant);
    Task DeleteAsync(Applicant applicant);
    Task<bool> IsIdentityNumberExists(string identityNumber);


}
