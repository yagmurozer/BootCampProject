using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class ApplicantRepository : EfRepositoryBase<Applicant, Guid, BaseDbContext>, IApplicantRepository
{
    private readonly BaseDbContext _context;
    public ApplicantRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<Applicant?> GetByIdAsync(Guid id)
    {
        return await _context.Applicants.FindAsync(id);
    }

    public async Task<bool> AnyAsync(Expression<Func<Applicant, bool>> predicate)
    {
        return await _context.Applicants.AnyAsync(predicate);
    }

    public async Task<List<Applicant>> GetAllAsync()
    {
        return await _context.Applicants.ToListAsync();
    }

    public async Task AddAsync(Applicant applicant)
    {
        await _context.Applicants.AddAsync(applicant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Applicant applicant)
    {
        _context.Applicants.Update(applicant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Applicant applicant)
    {
        _context.Applicants.Remove(applicant);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsIdentityNumberExists(string identityNumber)
    {
        return await _context.Applicants.AnyAsync(a => a.IdentityNumber == identityNumber);
    }

}
