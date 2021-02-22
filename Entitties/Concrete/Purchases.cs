using Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrute
{
    public class Purchases : IEntity
    {
        [Key]
        public int PurchaseId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PurchasePrice { get; set; }
    }
}
