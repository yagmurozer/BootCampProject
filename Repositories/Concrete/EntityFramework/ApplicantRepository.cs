using Core.Repositories.EntityFramework;
using Core.Security.Entites;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class ApplicantRepository : EfRepositoryBase<Applicant, Guid, BaseDbContext>, IApplicantRepository
{
    public ApplicantRepository(BaseDbContext context) : base(context)
    {
    }


}


