using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;

namespace Repositories.Concrete.EntityFramework;

public class ApplicationRepository : EfRepositoryBase<Application, Guid, BaseDbContext>, IApplicationRepository
{
    public ApplicationRepository(BaseDbContext context) : base(context)
    {

    }
}
