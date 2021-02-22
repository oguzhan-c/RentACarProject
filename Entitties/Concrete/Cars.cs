using Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrute
{
         public class Cars: IEntity
        {
            [Key]
            public int CarId { get; set; }
            public String Marque { get; set; }
            public String CarName { get; set; }
            public String Description { get; set; }
            public String Color { get; set; }
            public int BrandDate { get; set; }
            public String Plaque { get; set; }
            public decimal Price { get; set; }
        }
}
