using Core.Utilities.Results.Abstruct;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface ICustomerService
    {
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer> GetById(int id);
    }
}
