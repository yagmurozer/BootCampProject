using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class BlackListRepository : EfRepositoryBase<BlackList, Guid, BaseDbContext>, IBlackListRepository
{
    private readonly BaseDbContext _context;

    public BlackListRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<BlackList?> GetByIdAsync(Guid id)
    => await _context.BlackLists.FindAsync(id);

    public async Task<List<BlackList>> GetAllAsync()
        => await _context.BlackLists.ToListAsync();

    public async Task AddAsync(BlackList blackList)
    {
        await _context.BlackLists.AddAsync(blackList);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BlackList blackList)
    {
        _context.BlackLists.Update(blackList);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(BlackList blackList)
    {
        _context.BlackLists.Remove(blackList);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<BlackList, bool>> predicate)
        => await _context.BlackLists.AnyAsync(predicate);

    public async Task<bool> IsActiveBlackListEntryExists(Guid applicantId)
    {
        return await _context.BlackLists.AnyAsync(b => b.ApplicantId == applicantId);
    }

}
