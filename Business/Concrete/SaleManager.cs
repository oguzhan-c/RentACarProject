using Business.Abstruct;
using Business.Constat;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SaleManager : ISaleService
    {
        ISaleDal saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            this.saleDal = saleDal;
        }

        public IResult Add(Sale sale)
        {
            saleDal.Add(sale);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Sale sale)
        {
            saleDal.Delete(sale);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Sale>> GetAll()
        {
            return new SuccessDataResult<List<Sale>>(saleDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Sale> GetById(int id)
        {
            return new SuccessDataResult<Sale>(saleDal.Get(s=>s.SaleId == id),Messages.ListedById);
        }

        public IResult Update(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
