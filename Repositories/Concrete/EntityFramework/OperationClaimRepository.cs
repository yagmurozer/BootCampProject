using Core.Repositories.EntityFramework;
using Core.Security.Entites;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;


namespace Repositories.Concrete.EntityFramework;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}
