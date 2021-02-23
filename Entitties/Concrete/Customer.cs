using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public String CustomerName { get; set; }
        public String CustomerLastname { get; set; }
        public String Gender { get; set; }
        public String IdentityNumber { get; set; }
        public DateTime DateOfBorth { get; set; }
    }
}
