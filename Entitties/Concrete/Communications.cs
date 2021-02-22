using Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrute
{
    public class Communications : IEntity
    {
        [Key]
        public int CommunicationId { get; set; }
        public int CustomerId { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String Region { get; set; }
        public String Country { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String EmailAddress { get; set; }
        public String ZipCode { get; set; }
    }
}
