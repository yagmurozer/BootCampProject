using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extentions
{
    public static class ClaimPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal principal, string claimType)
        {
            var result = principal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal principal)
        {
            return principal?.Claims(ClaimTypes.Role);
        }

        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            return Guid.Parse(principal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
        }
    }
}
