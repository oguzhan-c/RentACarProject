using Business.Abstruct;
using Business.Constat;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct.DataAcessLayers;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SaleManager : ISaleService
    {
        ISaleDal saleDal;
        ICarService _carService;

        public SaleManager(ISaleDal saleDal , ICarService carService)
        {
            this.saleDal = saleDal;
            _carService = carService;
        }

        public IResult Add(Sale sale)
        {
            var result = BusinessRule.Run
                (
                    CheckIfCarCanNotSale(sale.CarId)
                );
            if (result != null)
            {
                return result;
            }
            saleDal.Add(sale);
            return new SuccessResult(SaleMessages.Added);
        }

        public IResult Delete(Sale sale)
        {
            saleDal.Delete(sale);
            return new SuccessResult(SaleMessages.Deleted);
        }

        public IDataResult<List<Sale>> GetAll()
        {
            return new SuccessDataResult<List<Sale>>(saleDal.GetAll(), SaleMessages.Listed);
        }

        public IDataResult<Sale> GetById(int id)
        {
            return new SuccessDataResult<Sale>(saleDal.Get(s=>s.SaleId == id), SaleMessages.ListedById);
        }

        public IResult Update(Sale sale)
        {
            saleDal.Update(sale);
            return new SuccessResult(SaleMessages.Updated);

        }

        private IResult CheckIfCarCanNotSale(int carId)
        {
            if (_carService.CheckIfCarAlreadyExist(carId).Succcess)
            {
                return new ErrorResult(SaleMessages.YouCanNotSaleThisCar);
            }
            return new SuccessResult();
        }
    }
}
