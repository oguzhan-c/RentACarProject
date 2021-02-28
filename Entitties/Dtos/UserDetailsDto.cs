using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserDetailsDto
    {
        public int UserId { get; set; }
        public String UserName { get; set; }
        public String UserLastName { get; set; }
        public String Gender { get; set; }
        public DateTime DateOfBorth { get; set; }
    }
}
