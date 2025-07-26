using Core.Repositories.EntityFramework;
using Core.Security.Entites;
using Entities;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete.EntityFramework;

public class UserRepository : EfRepositoryBase<User, Guid, BaseDbContext>, IUserRepository
{

    public UserRepository(BaseDbContext context) : base(context)
    {
       
    }
}
