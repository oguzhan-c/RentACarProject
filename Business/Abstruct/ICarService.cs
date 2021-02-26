
using Core.Utilities.Results.Abstruct;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetById(int carId);
    }
}
