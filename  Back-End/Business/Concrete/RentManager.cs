using Business.Abstruct;
using Business.Constat;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct.DataAcessLayers;
using Entities.Concrute;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal rentDal;
        ICarService _carService;

        public RentManager(IRentDal rentDal , ICarService carService)
        {
            this.rentDal = rentDal;
            _carService = carService;
        }

        public IResult Add(Rent rent)
        {
            var result = BusinessRule.Run
                (
                    CheckIfCarCanNotRent(rent.CarId)
                );
            if (result != null)
            {
                return result;
            }
            rentDal.Add(rent);
            return new SuccessResult(RentMessages.Added);
        }

        public IResult Delete(Rent rent)
        {
            rentDal.Delete(rent);
            return new SuccessResult(RentMessages.Deleted);

        }

        public IDataResult<List<Rent>> GetAll()
        {
            return new SuccessDataResult<List<Rent>>(rentDal.GetAll(), RentMessages.Listed);
        }

        public IDataResult<Rent> GetById(int id)
        {
            return new SuccessDataResult<Rent>(rentDal.Get(r=>r.RentId == id), RentMessages.ListedById);
        }

        public IDataResult<List<RentDetailDto>> GetRentDetails()
        {
            return new SuccessDataResult<List<RentDetailDto>>(rentDal.GetRentDetails(), RentMessages.RentDetailsListed);
        }

        public IResult Update(Rent rent)
        {
            rentDal.Update(rent);
            return new SuccessResult(RentMessages.Updated); 
        }

        private IResult CheckIfCarCanNotRent(int carId)
        {
            //Eğer araba varsa geriye ErrorResult(CarMessages.CarAlreadyExist) dönecektir.
            if (!_carService.CheckIfCarAlreadyExist(carId).Succcess)
            {
                var result = rentDal.Get(r => r.CarId == carId);
                if (result.ReturnDate > DateTime.Now)
                {
                    return new ErrorResult(RentMessages.CarIsAlreadyRentBySomeone);
                }
                return new SuccessResult();
            }
            return new ErrorResult(CarMessages.ThisCarIsNotExist);
        }
    }
}
