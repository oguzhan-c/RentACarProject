using Business.Abstruct;
using Business.Constat;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct.DataAcessLayers;
using Entities.Concrute;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.BusinessAsspects.Autofac;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRule.Run
                (
                    CheckIfCarAlreadyExist(car.CarId)
                );
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(CarMessages.Added);
        }

        public IResult CheckIfCarAlreadyExist(int carId)
        {
            var result = _carDal.GetAll(c => c.CarId == carId).Any();
            if (result)
            {
                return new ErrorResult(CarMessages.CarAlreadyExist);
            }
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(CarMessages.Deleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), CarMessages.Listed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId == carId), CarMessages.ListedById);
        }

        public IResult Update(Car car)
        {
            Update(car);
            return new  SuccessResult(CarMessages.Updated);
        }
    }
}
