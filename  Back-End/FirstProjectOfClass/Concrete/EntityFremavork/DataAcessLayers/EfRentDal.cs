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
                             join u in context.Users
                             on r.UserId equals u.UserId
                             select new RentDetailDto
                             {
                                 RentId = r.RentId,
                                 CarName = c.CarName,
                                 CustomerName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 UseAge = (r.ReturnDate - r.RentDate).Days ,
                                 DailyPrce = r.DailyPrice,
                                 TotalPrice = r.UseAge * r.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
