using Business.Abstruct;
using Business.Constat;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct.DataAcessLayers;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CommunicationManager : ICommunicationService
    {
        ICommunicationDal communicationDal;
        ICustomerService _customerService;

        public CommunicationManager(ICommunicationDal communicationDal , ICustomerService customerService)
        {
            this.communicationDal = communicationDal;
            _customerService = customerService;
        }

        public IResult Add(Communication communication)
        {
            var result = BusinessRule.Run
                (
                    CheckIfComminucationAlreadyExist(communication.CustomerId)
                );
            if (result != null)
            {
                return result;
            }
            communicationDal.Add(communication);
            return new SuccessResult(CommunicationMessages.Added);
        }

        public IResult Delete(Communication communication)
        {
            communicationDal.Delete(communication);
            return new SuccessResult(CommunicationMessages.Deleted);
        }

        public IDataResult<List<Communication>> GetAll()
        {
           
            return new SuccessDataResult<List<Communication>>(communicationDal.GetAll(), CommunicationMessages.Listed);
        }
        public IDataResult<List<Communication>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Communication>>(communicationDal.GetAll(c=>c.CustomerId == customerId));
        }

        public IResult Update(Communication communication)
        {
            communicationDal.Update(communication);
            return new SuccessResult(CommunicationMessages.Updated);
        }

        private IResult CheckIfComminucationAlreadyExist(int customerId)
        {
            if (!_customerService.CheckIfCustomerAlreadyExist(customerId).Succcess)
            {
                var result = communicationDal.GetAll(c => c.CustomerId == customerId).Any();
                if (result)
                {
                    return new ErrorResult(CommunicationMessages.ComminucationAlreadyExist);
                }
                return new SuccessResult();
            }
            return new ErrorResult(CustomerMessages.ThisCustomerIsNotExist);
        }
    }

}
