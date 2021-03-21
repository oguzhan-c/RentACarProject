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
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRule.Run
                (
                    CheckIfCarAlreadyExist(car.Id)
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
            var result = _carDal.GetAll(c => c.Id == carId).Any();
            if (result)
            {
                return new ErrorResult(CarMessages.CarAlreadyExist);
            }
            return new SuccessResult();
        }

        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(CarMessages.Deleted);
        }

        [CacheAspect]
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll().Any();
            if (result)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), CarMessages.Listed);
            }

            return new ErrorDataResult<List<Car>>(CarImageMessages.NeverCarAdded);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id == carId), CarMessages.ListedById);
        }

        [CacheRemoveAspect("IproductService.Get")]
        public IResult Update(Car car)
        {
            Update(car);
            return new  SuccessResult(CarMessages.Updated);
        }
    }
}
