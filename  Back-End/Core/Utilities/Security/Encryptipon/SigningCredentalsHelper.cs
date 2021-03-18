using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryptipon
{
    public class SigningCredentalsHelper
    {
        public static SigningCredentials CreateSigningCredentals(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}