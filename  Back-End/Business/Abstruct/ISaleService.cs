using Core.Utilities.Results.Abstruct;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface ISaleService
    {
        IDataResult<List<Sale>> GetAll();
        IResult Add(Sale sale);
        IResult Delete(Sale sale);
        IResult Update(Sale sale);
        IDataResult<Sale> GetById(int id);
    }
}
