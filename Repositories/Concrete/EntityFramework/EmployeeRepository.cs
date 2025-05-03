using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;

namespace Repositories.Concrete.EntityFramework;

public class EmployeeRepository : EfRepositoryBase<Employee, Guid, BaseDbContext>, IEmployeeRepository
{
    public EmployeeRepository(BaseDbContext context) : base(context)
    {
    }
}
