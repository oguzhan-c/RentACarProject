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
    public class EfUserDal : EfEntitiyRepositoryBase<User, RentACarContext>, IUserDal { 
        public List<OperationClaim> GetClaims(User user)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from OperationClaim in context.OperationClaims
                    join UserOperationClaim in context.UserOperationClaims
                        on OperationClaim.claimId equals UserOperationClaim.UserOperationClaimId
                        where UserOperationClaim.UserId == user.UserId
                             select new OperationClaim{claimId = OperationClaim.claimId , Name = OperationClaim.Name};

                return result.ToList();
            }
        }

        public IDataResult<List<UserDetailsDto>> GetUserDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new UserDetailsDto
                             {
                                 UserId = u.UserId,
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
