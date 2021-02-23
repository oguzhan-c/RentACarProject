using Business.Abstruct;
using DataAccess.Abstruct;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
        }

        public List<Customer> GetAll()
        {
            return customerDal.GetAll();
        }

        public List<CustomerDetailDto> GetCustomerDetails()
        {
            return customerDal.GetCustomerDetails();
        }
    }
}
