using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppData.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string TelNo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        
        public Payment Payment { get; set; }
        public Profile Profile { get; set; }
        public NutritionPackage NutritionPackage { get; set; }
        public FitnessPackage FitnessPackage { get; set; }

        public IEnumerable<FitnessSchedule> FitnessSchedules { get; set; }
    }
}
