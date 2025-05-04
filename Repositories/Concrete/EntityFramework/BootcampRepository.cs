using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;

namespace Repositories.Concrete.EntityFramework;

public class BootcampRepository : EfRepositoryBase<Bootcamp, Guid, BaseDbContext>, IBootcampRepository
{
    public BootcampRepository(BaseDbContext context) : base(context)
    {

    }
}
