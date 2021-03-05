using Business.Abstruct;
using Business.Constat;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct.DataAcessLayers;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CommunicationManager : ICommunicationService
    {
        ICommunicationDal communicationDal;

        public CommunicationManager(ICommunicationDal communicationDal)
        {
            this.communicationDal = communicationDal;
        }

        public IResult Add(Communication communication)
        {
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
    }

}
