using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface ICustomerService
    {
        List<Customer> GetAll();

        List<CustomerDetailDto> GetCustomerDetails();
    }
}
