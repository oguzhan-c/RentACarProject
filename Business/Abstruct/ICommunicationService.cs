using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface ICommunicationService
    {
        List<Communication> GetAll();
    }
}
