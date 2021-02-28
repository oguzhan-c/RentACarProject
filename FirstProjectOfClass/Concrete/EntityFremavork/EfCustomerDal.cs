using Core.DataAcces.EntitiyFramework;
using DataAccess.Abstruct;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFremavork
{
    public class EfCustomerDal : EfEntitiyRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {

        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                //from r in context.Rent
                //join c in context.Cars
                //on r.CarId equals c.CarId

                var result = from cu in context.Customers
                             join co in context.Communications
                             on cu.CustomerId equals co.CustomerId
                             select new CustomerDetailDto
                             {
                                 CustomerId = cu.CustomerId,
                                 CustomerName = cu.CustomerName,
                                 CustomerLastname = cu.CustomerLastname,
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
