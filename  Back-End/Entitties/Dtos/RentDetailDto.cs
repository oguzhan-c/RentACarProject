using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RentDetailDto
    {
        public int RentId { get; set; }
        public String CustomerName { get; set; }
        public String CustomerLastName { get; set; }
        public String CarName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int UseAge { get; set; }
        public decimal DailyPrce { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
