using Core.Utilities.Results.Abstruct;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface IPurchaseService
    {
        IDataResult<List<Purchase>> GetAll();
        IResult Add(Purchase purchase);
        IResult Delete(Purchase purchase);
        IResult Update(Purchase purchase);
        IDataResult<Purchase> GetById(int id);
    }
}
