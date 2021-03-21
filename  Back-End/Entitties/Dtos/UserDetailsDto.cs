using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String UserLastName { get; set; }
        public String Gender { get; set; }
        public DateTime DateOfBorth { get; set; }
        public String Email { get; set; }
        public String SaveEmail { get; set; }
    }
}
