using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppData.Models
{
    public class FitnessSchedule
    {
        public int Id { get; set; }
        public DateTime FitnessDate { get; set; }
        public FitnessType FitnessType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
