using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entites
{
    public class OperationClaim: BaseEntity<int>  //Sistemdeki roller/izinler (Admin, Write, Read vs.).
    {
        public string Name { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public OperationClaim()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public OperationClaim(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
