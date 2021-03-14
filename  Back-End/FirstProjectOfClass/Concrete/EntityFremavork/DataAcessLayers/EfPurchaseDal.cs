using Core.DataAcces.EntitiyFramework;
using DataAccess.Abstruct.DataAcessLayers;
using DataAccess.Concrete.EntityFremavork.DatabaseContexts;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFremavork.DataAcessLayers
{
    public class EfPurchaseDal : EfEntitiyRepositoryBase<Purchase, RentACarContext>, IPurchaseDal
    {
    }
}
