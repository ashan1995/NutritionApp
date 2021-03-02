using FitnessAppData.Models.HelperModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

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
        public string VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }


        [JsonIgnore]
        public Payment Payment { get; set; }
        [JsonIgnore]
        public Profile Profile { get; set; }
        public NutritionPackage NutritionPackage { get; set; }
        public FitnessPackage FitnessPackage { get; set; }

        [JsonIgnore]
        public IEnumerable<FitnessSchedule> FitnessSchedules { get; set; }
    }
}
