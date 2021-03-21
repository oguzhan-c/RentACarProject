using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrute
{
         public class Car: IEntity
        {
            [Key]
            public int Id { get; set; }
            public String Marque { get; set; }
            public String CarName { get; set; }
            public String Description { get; set; }
            public String Color { get; set; }
            public int BrandDate { get; set; }
            public String Plaque { get; set; }
            public decimal Price { get; set; }
        }
}
