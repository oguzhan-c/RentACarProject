using DataAccess.Abstruct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.DataAcces.EntitiyFramework;
using Entities.Concrute;

namespace DataAccess.Concrete.EntityFremavork
{
    //NuGet
    public class EfCarDal : EfEntitiyRepositoryBase<Car, RentACarContext>, ICarDal
    {
        
    }
}
