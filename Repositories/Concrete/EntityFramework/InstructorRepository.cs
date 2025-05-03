using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Concrete.EntityFramework.Context;

namespace Repositories.Concrete.EntityFramework;

public class InstructorRepository : EfRepositoryBase<Instructor, Guid, BaseDbContext>
{
    public InstructorRepository(BaseDbContext context) : base(context)
    {

    }
}
