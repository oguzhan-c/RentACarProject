using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public String UserEmail { get; set; }
        public String UserPassword { get; set; }
        public String ImageReferance { get; set; }
    }
}
