using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class BootcampRepository : EfRepositoryBase<Bootcamp, Guid, BaseDbContext>, IBootcampRepository
{
    private readonly BaseDbContext _context;

    public BootcampRepository(BaseDbContext context) : base(context)
    {
        _context = context;

    }

    public async Task<Bootcamp?> GetByIdAsync(Guid id)
    => await _context.Bootcamps.FindAsync(id);

    public async Task<List<Bootcamp>> GetAllAsync()
        => await _context.Bootcamps.ToListAsync();

    public async Task AddAsync(Bootcamp bootcamp)
    {
        await _context.Bootcamps.AddAsync(bootcamp);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Bootcamp bootcamp)
    {
        _context.Bootcamps.Update(bootcamp);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Bootcamp bootcamp)
    {
        _context.Bootcamps.Remove(bootcamp);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<Bootcamp, bool>> predicate)
        => await _context.Bootcamps.AnyAsync(predicate);
}
