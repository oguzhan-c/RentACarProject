using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CustomerDetailDto : IDto
    {
        public int Id { get; set; }
        public String CustomerName { get; set; }
        public String CustomerLastname { get; set; }
        public String Gender { get; set; }
        public String IdentityNumber { get; set; }
        public DateTime DateOfBorth { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String Region { get; set; }
        public String Country { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String ZipCode { get; set; }
        public string SaveEmail { get; set; }
    }
}
