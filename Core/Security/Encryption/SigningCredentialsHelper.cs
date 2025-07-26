using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //Tokeni kriptografik olarak imzalar
        // Tokenin içeriği değiştirilmesin diye kullanılır
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
