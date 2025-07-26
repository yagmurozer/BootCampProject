using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class ApplicationRepository : EfRepositoryBase<Application, Guid, BaseDbContext>, IApplicationRepository
{
    public ApplicationRepository(BaseDbContext context) : base(context)
    {

    }

 
}
