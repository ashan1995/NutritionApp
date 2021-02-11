using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppData.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float BMI { get; set; }
        public float BodyFat { get; set; }
        public DateTime WakeupTime { get; set; }
        public DateTime SleepTime { get; set; }
        public string CurrentWorkoutPlan { get; set; }
        public string WorkoutDietTarget { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
