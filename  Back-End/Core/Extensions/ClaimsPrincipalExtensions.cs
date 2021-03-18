using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //ClaimsPrincipal jwt den gelen kişinin claimlerine erişmek için kullanılabilir
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            //? null olabileceğini söyler ? nul dönmesini söyler eğer nullsa
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}