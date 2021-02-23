using Core.DataAcces.EntitiyFramework;
using DataAccess.Abstruct;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFremavork
{
    public class EfSaleDal : EfEntitiyRepositoryBase<Sale,RentACarContext>,ISaleDal
    {
    }
}
