using Core.DataAcces.EntitiyFramework;
using DataAccess.Abstruct.DataAcessLayers;
using DataAccess.Concrete.EntityFremavork.DatabaseContexts;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFremavork.DataAcessLayers
{
    public class EfCarImageDal : EfEntitiyRepositoryBase<CarImage,RentACarContext>,ICarImageDal
    {
    }
}
