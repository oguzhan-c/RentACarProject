using Core.DataAcces;
using Entities.Concrute;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstruct
{
    public interface IRentDal : IEntityRepository<Rent>
    {
        List<RentDetailDto> GetRentDetails();
    }
}
