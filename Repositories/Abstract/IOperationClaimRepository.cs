using Core.Repositories;
using Core.Security.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public interface IOperationClaimRepository : IRepository<OperationClaim, int>
    {
    }
}
