﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessAppData.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email{ get; set; }

        [Required]
        public string Password { get; set; }
    }
}
