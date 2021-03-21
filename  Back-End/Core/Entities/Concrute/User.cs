using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Concrute
{
    public class User : IEntity
    {
        [Key]
        public int Id{ get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String  UserEmail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public String SaveEmail { get; set; }
        public String UserImagePath { get; set; }
    }
}
