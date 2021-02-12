using FitnessAppData;
using FitnessAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessAppServices
{
    public class ScheduleService : IScheduleData
    {
        private readonly FitnessAppContext _context;

        public ScheduleService(FitnessAppContext context) {
            _context = context;
        }

        public void AddScedule(FitnessSchedule fitnessSchedule)
        {
            _context.Add(fitnessSchedule);
            _context.SaveChanges();
        }

        public FitnessSchedule GetFitnessScheduleById(int id)
        {
            return _context.FitnessSchedules.FirstOrDefault(asset => asset.Id == id);
        }

        public IEnumerable<FitnessSchedule> GetFitnessSchedules()
        {
            return _context.FitnessSchedules;
        }

        public FitnessType GetFitnessTypeById(int id)
        {
            return _context.FitnessTypes.FirstOrDefault(asset => asset.Id == id);
        }

      
    }
}
