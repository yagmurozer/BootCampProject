using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;

namespace Repositories.Concrete.EntityFramework;

public class ApplicantionRepository : EfRepositoryBase<Application, Guid, BaseDbContext>, IApplicationRepository
{
    public ApplicantionRepository(BaseDbContext context) : base(context)
    {

    }
}
