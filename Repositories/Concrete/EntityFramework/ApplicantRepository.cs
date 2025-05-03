using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;

namespace Repositories.Concrete.EntityFramework;

public class ApplicantRepository : EfRepositoryBase<Applicant, Guid, BaseDbContext>, IApplicantRepository
{
    public ApplicantRepository(BaseDbContext context) : base(context)
    {

    }
}
