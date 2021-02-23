using Business.Abstruct;
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

        public List<Sale> GetAll()
        {
            return saleDal.GetAll();
        }
    }
}
