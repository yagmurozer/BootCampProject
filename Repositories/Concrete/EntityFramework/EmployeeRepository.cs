using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class EmployeeRepository : EfRepositoryBase<Employee, Guid, BaseDbContext>, IEmployeeRepository
{

    public EmployeeRepository(BaseDbContext context) : base(context)
    {
    }


}
