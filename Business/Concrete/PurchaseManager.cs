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
    public class PurchaseManager : IPurchaseService
    {
        IPurchaseDal purchaseDal;

        public PurchaseManager(IPurchaseDal purchaseDal)
        {
            this.purchaseDal = purchaseDal;
        }

        public IResult Add(Purchase purchase)
        {
            purchaseDal.Add(purchase);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Purchase purchase)
        {
            purchaseDal.Delete(purchase);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Purchase>> GetAll()
        {
            return new SuccessDataResult<List<Purchase>>(purchaseDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Purchase> GetById(int id)
        {
            return new SuccessDataResult<Purchase>(purchaseDal.Get(p=>p.PurchaseId == id),Messages.ListedById);
        }

        public IResult Update(Purchase purchase)
        {
            purchaseDal.Update(purchase);
            return new SuccessResult(Messages.Updated);
        }
    }
}
