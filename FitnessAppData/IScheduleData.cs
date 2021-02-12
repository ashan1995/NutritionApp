using FitnessAppData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppData
{
    public interface IScheduleData
    {
        void AddScedule(FitnessSchedule fitnessSchedule);

        IEnumerable<FitnessSchedule> GetFitnessSchedules();


        FitnessSchedule GetFitnessScheduleById(int id);

        FitnessType GetFitnessTypeById(int id);


    }
}
