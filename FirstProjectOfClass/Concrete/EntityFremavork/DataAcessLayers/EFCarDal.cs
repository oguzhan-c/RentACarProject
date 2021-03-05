using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.DataAcces.EntitiyFramework;
using Entities.Concrute;
using DataAccess.Concrete.EntityFremavork.DatabaseContexts;
using DataAccess.Abstruct.DataAcessLayers;

namespace DataAccess.Concrete.EntityFremavork.DataAcessLayers
{
    //NuGet
    public class EfCarDal : EfEntitiyRepositoryBase<Car, RentACarContext>, ICarDal
    {

    }
}
