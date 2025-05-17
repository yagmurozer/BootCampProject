using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class ApplicationRepository : EfRepositoryBase<Application, Guid, BaseDbContext>, IApplicationRepository
{
    private readonly BaseDbContext _context;
    public ApplicationRepository(BaseDbContext context) : base(context)
    {
        _context = context;  

    }

    public async Task<Application?> GetByIdAsync(Guid id)
    => await _context.Applications.FindAsync(id);

    public async Task<List<Application>> GetAllAsync()
        => await _context.Applications.ToListAsync();

    public async Task AddAsync(Application application)
    {
        await _context.Applications.AddAsync(application);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Application application)
    {
        _context.Applications.Update(application);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Application application)
    {
        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<Application, bool>> predicate)
        => await _context.Applications.AnyAsync(predicate);

}
