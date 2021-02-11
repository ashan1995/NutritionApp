using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string TelNo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int NutritionPackage { get; set; }
        public int FitnessPackage { get; set; }
    }
}
