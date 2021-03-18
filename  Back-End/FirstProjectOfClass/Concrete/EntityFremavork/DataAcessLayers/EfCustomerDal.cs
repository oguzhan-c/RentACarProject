using Core.DataAcces.EntitiyFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrute;
using DataAccess.Concrete.EntityFremavork.DatabaseContexts;
using DataAccess.Abstruct.DataAcessLayers;

namespace DataAccess.Concrete.EntityFremavork.DataAcessLayers
{
    public class EfCustomerDal : EfEntitiyRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {

        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cu in context.Customers
                             join co in context.Communications
                             on cu.CustomerId equals co.CustomerId
                             join u in context.Users 
                                 on cu.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = cu.CustomerId,
                                 CustomerName = u.FirstName,
                                 CustomerLastname =u.LastName,
                                 Gender = cu.Gender,
                                 IdentityNumber = cu.IdentityNumber,
                                 DateOfBorth = cu.DateOfBorth,
                                 Street = co.Street,
                                 City = co.City,
                                 Region = co.Region,
                                 Country = co.Country,
                                 Address = co.Address,
                                 PhoneNumber = co.PhoneNumber,
                                 SaveEmail = co.SaveEmail,
                                 ZipCode = co.ZipCode
                             };


                return result.ToList();
            }
        }
    }
}
