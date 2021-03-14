using Core.DataAcces.EntitiyFramework;
using Entities.Concrute;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Concrete.EntityFremavork.DatabaseContexts;
using DataAccess.Abstruct.DataAcessLayers;

namespace DataAccess.Concrete.EntityFremavork.DataAcessLayers
{
    public class EfRentDal : EfEntitiyRepositoryBase<Rent, RentACarContext>, IRentDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rent
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             select new RentDetailDto
                             {
                                 RentId = r.RentId,
                                 CarName = c.CarName,
                                 CustomerName = cu.CustomerName,
                                 CustomerLastName = cu.
                                 CustomerLastname,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrce = r.DailyPrice,

                             };

                return result.ToList();


            }
        }
    }
}
