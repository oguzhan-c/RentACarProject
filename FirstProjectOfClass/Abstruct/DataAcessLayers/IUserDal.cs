using Core.DataAcces;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstruct.DataAcessLayers
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserDetailsDto> GetUserDetails();
    }
}
