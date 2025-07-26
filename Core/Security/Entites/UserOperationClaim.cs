using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entites
{
    public class UserOperationClaim : BaseEntity<int>   //Hangi kullanıcı hangi role sahip?
    {
        public Guid UserId { get; set; }
        public int OperationClaimId { get; set; }

        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }


        public UserOperationClaim()
        {

        }

        public UserOperationClaim(int id, Guid userId, int operationClaimId)
        {
            Id = id;
            UserId = userId;
            OperationClaimId = operationClaimId;
        }
    }
}
