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

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService; 

        public CarImageManager(ICarImageDal carImageDal , ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService ;
        }

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
            var fileUpload = FileHelper.Add(file);
            if (fileUpload.Succcess)
            {
                carImage.ImagePath = fileUpload.Data;
                _carImageDal.Add(carImage);
                return new SuccessResult();
            }
            return new ErrorResult(CarImageMessages.CarImageDidNotAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(CarImageMessages.Deleted);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get)
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfCarImageEmpty(int carId,int carImageId)
        {
            if (!_carService.CheckIfCarAlreadyExist(carId).Succcess)
            {
                String sourcePath = @"\wwwroot\Images\logo.jpg";

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
