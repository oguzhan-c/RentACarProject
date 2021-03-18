using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrute
{
    public class Sale : IEntity
    {
        [Key]
        public int SaleId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime BuyingDate { get; set; }
        public decimal SalePrice { get; set; }
    }
}
