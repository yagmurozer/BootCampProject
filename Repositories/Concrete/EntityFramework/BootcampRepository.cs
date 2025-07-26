using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class BootcampRepository : EfRepositoryBase<Bootcamp, Guid, BaseDbContext>, IBootcampRepository
{

    public BootcampRepository(BaseDbContext context) : base(context)
    {

    }


}
