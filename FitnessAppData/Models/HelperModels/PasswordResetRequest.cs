using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppData.Models.HelperModels
{
    public class PasswordResetRequest
    {
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
