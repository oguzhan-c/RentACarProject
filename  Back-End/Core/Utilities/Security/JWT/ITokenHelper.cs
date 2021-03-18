using System.Collections.Generic;
using Core.Entities.Concrute;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken createToken(User user, List<OperationClaim> operationClaims);
    }
}