using Entities.Concrute;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface IRentService
    {
        List<Rent> GetAll();
        List<RentDetailDto> GetRentDetails();
    }
}
