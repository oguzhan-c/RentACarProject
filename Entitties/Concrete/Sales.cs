using Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrute
{
    public class Sales : IEntity
    {
        [Key]
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime BuyingDate { get; set; }
        public double SalePrice { get; set; }
    }
}
