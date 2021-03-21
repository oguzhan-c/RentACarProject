using Core.DataAcces.EntitiyFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrute;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using Entities.Dtos;
using DataAccess.Concrete.EntityFremavork.DatabaseContexts;
using DataAccess.Abstruct.DataAcessLayers;

namespace DataAccess.Concrete.EntityFremavork.DataAcessLayers
{
    public class EfUserDal : EfEntitiyRepositoryBase<User, RentACarContext>, IUserDal
    {
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var context = new RentACarContext();
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

            return new SuccessDataResult<List<OperationClaim>>(result.ToList());
        }

        public IDataResult<List<UserDetailsDto>> GetUserDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             select new UserDetailsDto
                             {
                                 Id = u.Id,
                                 UserName = u.FirstName,
                                 UserLastName = u.LastName,
                                 Gender = c.Gender,
                                 DateOfBorth = c.DateOfBorth,
                                 Email = u.UserEmail,
                                 SaveEmail = u.SaveEmail,
                             };
                return new SuccessDataResult<List<UserDetailsDto>>(result.ToList());

            }
        }
    }
}
