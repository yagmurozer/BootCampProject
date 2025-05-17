using Core.Repositories;
using Entities;
using System.Linq.Expressions;

namespace Repositories.Abstract;

public interface IBlackListRepository : IRepository<BlackList,Guid>
{
    Task<BlackList?> GetByIdAsync(Guid id);
    Task<List<BlackList>> GetAllAsync();
    Task AddAsync(BlackList blackList);
    Task UpdateAsync(BlackList blackList);
    Task DeleteAsync(BlackList blackList);
    Task<bool> AnyAsync(Expression<Func<BlackList, bool>> predicate);
    Task<bool> IsActiveBlackListEntryExists(Guid applicantId);


}
