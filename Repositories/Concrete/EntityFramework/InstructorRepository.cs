using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class InstructorRepository : EfRepositoryBase<Instructor, Guid, BaseDbContext>, IInstructorRepository
{
    private readonly BaseDbContext _context;

    public InstructorRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Instructor?> GetByIdAsync(Guid id)
    => await _context.Instructors.FindAsync(id);

    public async Task<List<Instructor>> GetAllAsync()
        => await _context.Instructors.ToListAsync();

    public async Task AddAsync(Instructor instructor)
    {
        await _context.Instructors.AddAsync(instructor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Instructor instructor)
    {
        _context.Instructors.Update(instructor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Instructor instructor)
    {
        _context.Instructors.Remove(instructor);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<Instructor, bool>> predicate)
        => await _context.Instructors.AnyAsync(predicate);
}
