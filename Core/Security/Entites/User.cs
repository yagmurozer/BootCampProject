using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entites
{
    public class User : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string IdentityNumber { get; set; }      
        public string NationalIdentity { get; set; }      
        public DateTime DateOfBirth { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public User(Guid id, string firstName, string lastName, string email,
                    string identityNumber, string nationalIdentity, DateTime dateOfBirth,
                    byte[] passwordHash, byte[] passwordSalt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IdentityNumber = identityNumber;
            NationalIdentity = nationalIdentity;
            DateOfBirth = dateOfBirth;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
    }
}
