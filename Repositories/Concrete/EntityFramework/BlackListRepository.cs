using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework;

public class BlackListRepository : EfRepositoryBase<BlackList, Guid, BaseDbContext>, IBlackListRepository
{

    public BlackListRepository(BaseDbContext context) : base(context)
    {
    }



}
