using Business.Abstruct;
using Business.Constat;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct.DataAcessLayers;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = BusinessRule.Run
                (
                    CheckIfCustomerAlreadyExist(customer.Id)
                );
            if (result != null)
            {
                return result;
            }
            customerDal.Add(customer);
            return new SuccessResult(CustomerMessages.Added);
        }

        public IResult CheckIfCustomerAlreadyExist(int customerId)
        {
            {
                var result = customerDal.GetAll(c => c.Id == customerId).Any();

                if (result)
                {
                    return new ErrorResult(CustomerMessages.CustomerAlreadyExist);
                }
                return new SuccessResult();
            }
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
            customerDal.GetAll(c => c.Id == id);
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
