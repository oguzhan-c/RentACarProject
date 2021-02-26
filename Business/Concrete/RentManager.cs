using Business.Abstruct;
using Business.Constat;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
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

        public IResult Add(Rent rent)
        {
            rentDal.Add(rent);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rent rent)
        {
            rentDal.Delete(rent);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<Rent>> GetAll()
        {
            return new SuccessDataResult<List<Rent>>(rentDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rent> GetById(int id)
        {
            return new SuccessDataResult<Rent>(rentDal.Get(r=>r.RentId == id),Messages.ListedById);
        }

        public IDataResult<List<RentDetailDto>> GetRentDetails()
        {
            return new SuccessDataResult<List<RentDetailDto>>(rentDal.GetRentDetails(), Messages.RentDetailsListed);
        }

        public IResult Update(Rent rent)
        {
            rentDal.Update(rent);
            return new SuccessResult(Messages.Updated); 
        }
    }
}
