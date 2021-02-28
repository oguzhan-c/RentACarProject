using Core.DataAcces.EntitiyFramework;
using DataAccess.Abstruct;
using DataAccess.Concrete.EntityFremavork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFremavork
{
    public class EfUserDal : EfEntitiyRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<UserDetailsDto> GetUserDetails()
        {
            using (RentACarContext context = new  RentACarContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new UserDetailsDto
                             {
                                 UserId = u.UserId,
                                 UserName = c.CustomerName,
                                 UserLastName = c.CustomerLastname,
                                 Gender = c.Gender,
                                 DateOfBorth = c.DateOfBorth
                             };
                return result.ToList();
            }
        }
    }
}
