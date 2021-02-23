using Business.Abstruct;
using DataAccess.Abstruct;
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

        public List<Communication> GetAll()
        {
            return communicationDal.GetAll();
        }
    }

}
