using Core.DataAcces;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrute;
using Core.Utilities.Results.Abstruct;

namespace DataAccess.Abstruct.DataAcessLayers
{
    public interface IUserDal : IEntityRepository<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<UserDetailsDto>> GetUserDetails();
    }
}
