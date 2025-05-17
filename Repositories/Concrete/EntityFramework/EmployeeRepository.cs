using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class EmployeeRepository : EfRepositoryBase<Employee, Guid, BaseDbContext>, IEmployeeRepository
{
    private readonly BaseDbContext _context;

    public EmployeeRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    => await _context.Employees.FindAsync(id);

    public async Task<List<Employee>> GetAllAsync()
        => await _context.Employees.ToListAsync();

    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Employee employee)
    {
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<Employee, bool>> predicate)
        => await _context.Employees.AnyAsync(predicate);
}
