using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class InstructorRepository : EfRepositoryBase<Instructor, Guid, BaseDbContext>, IInstructorRepository
{

    public InstructorRepository(BaseDbContext context) : base(context)
    {
    }


}
