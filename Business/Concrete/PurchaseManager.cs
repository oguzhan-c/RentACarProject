using Business.Abstruct;
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

        public List<Purchase> GetAll()
        {
            return purchaseDal.GetAll();
        }

    }
}
