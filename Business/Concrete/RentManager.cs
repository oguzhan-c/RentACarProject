using Business.Abstruct;
using DataAccess.Abstruct;
using Entities.Concrute;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal rentDal;

        public RentManager(IRentDal rentDal)
        {
            this.rentDal = rentDal;
        }

        public List<Rent> GetAll()
        {
            return rentDal.GetAll();
        }

        public List<RentDetailDto> GetRentDetails()
        {
            return rentDal.GetRentDetails();
        }
    }
}
