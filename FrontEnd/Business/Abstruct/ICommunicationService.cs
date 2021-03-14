using Core.Utilities.Results.Abstruct;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface ICommunicationService
    {
        IDataResult<List<Communication>> GetAll();
        IDataResult<List<Communication>> GetByCustomerId(int customerId);
        IResult Add(Communication communication);
        IResult Delete(Communication communication);
        IResult Update(Communication communication);

    }
}
