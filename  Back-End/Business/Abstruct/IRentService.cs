using Core.Utilities.Results.Abstruct;
using Entities.Concrute;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface IRentService
    {
        IDataResult<List<Rent>> GetAll();
        IResult Add(Rent rent);
        IResult Delete(Rent rent);
        IResult Update(Rent rent);
        IDataResult<Rent> GetById(int id);
        IDataResult<List<RentDetailDto>> GetRentDetails();
    }
}
