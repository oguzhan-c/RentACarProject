using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrute
{
    public class Rent : IEntity
    {
        [Key]
        public int RentId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int UseAge { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }

}
