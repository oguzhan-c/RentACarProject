using Business.Abstruct;
using Business.Constat;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct.DataAcessLayers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.BusinessAsspects.Autofac;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        readonly ICarImageDal _carImageDal;
        readonly ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [SecuredOperation("carImage.add,admin")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRule.Run
                (
                    CheckIfImageAlreadyExist(carImage.CarImageId),
                    CheckIfImageLimitExceed(carImage.CarId)
                );
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();

            return new ErrorResult(CarImageMessages.CarImageDidNotAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(CarImageMessages.Deleted);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<CarImage>> GetAll()
        {
            if (_carImageDal.GetAll().Any())
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
            }

            return new ErrorDataResult<List<CarImage>>(CarImageMessages.CarImagesIsNot);

        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            if (_carImageDal.GetAll(c => c.CarImageId == carImageId).Any())
            {
                return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId));
            }

            return new ErrorDataResult<CarImage>(CarImageMessages.CarImagesIsNoy);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarId == carId).Any())
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
            }

            return new ErrorDataResult<List<CarImage>>(CarMessages.ThisCarIsNotExist);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(file, _carImageDal.Get(c => c.CarImageId == carImage.CarImageId).ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageEmpty(int carId, int carImageId)
        {
            if (!_carService.CheckIfCarAlreadyExist(carId).Succcess)
            {
                String sourcePath = @"\wwwroot\Updates\logo.jpg";

                if (CheckIfImageAlreadyExist(carImageId).Succcess)
                {
                    List<CarImage> defaultCarImage = new List<CarImage>();

                    CarImage carImage = new CarImage();
                    carImage.CarId = carId;
                    carImage.Date = DateTime.Now;
                    carImage.ImagePath = sourcePath;

                    defaultCarImage.Add(carImage);

                    return new SuccessResult();
                }
                return new ErrorResult(CarImageMessages.CarImageAlreadyExist);
            }
            else
            {
                return new ErrorResult(CarMessages.ThisCarIsNotExist);
            }

        }

        private IResult CheckIfImageAlreadyExist(int carImageId)
        {
            var result = _carImageDal.GetAll(c => c.CarImageId == carImageId).Any();
            if (result)
            {
                return new ErrorResult(CarImageMessages.ImageAlreadyExist);
            }
            return new SuccessResult();

        }

        private IResult CheckIfImageLimitExceed(int carId)
        {
            int countOfSameCarImages = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (countOfSameCarImages > 5)
            {
                return new ErrorResult(CarImageMessages.CarImagesLimitExceed);
            }
            return new SuccessResult();
        }
    }
}
