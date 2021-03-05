using Business.Abstruct;
using Business.Constat;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct.DataAcessLayers;
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

        public IResult Add(Customer customer)
        {
            customerDal.Add(customer);
            return new SuccessResult(CustomerMessages.Added);
        }

        public IResult Delete(Customer customer)
        {
            customerDal.Delete(customer);

            return new SuccessResult(CustomerMessages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(customerDal.GetAll(), CustomerMessages.Listed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            customerDal.GetAll(c => c.CustomerId == id);
            return new SuccessDataResult<Customer>(CustomerMessages.ListedById);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(customerDal.GetCustomerDetails(), CustomerMessages.CustomerDetailsListed);
        }

        public IResult Update(Customer customer)
        {
            customerDal.Update(customer);
            return new SuccessResult(CustomerMessages.Updated);
        }
    }
}
