﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Concrute
{
    public class OperationClaim : IEntity
    {
        [Key]
        public int claimId { get; set; }
        public String Name { get; set; }
    }
}