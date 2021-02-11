using FitnessAppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppData
{
    public class FitnessAppContext:DbContext
    {
        public FitnessAppContext(DbContextOptions options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<FitnessPackage> FitnessPackages { get; set; }
        public DbSet<FitnessSchedule> FitnessSchedules { get; set; }
        public DbSet<FitnessType> FitnessTypes { get; set; }
        public DbSet<NutritionPackage> NutritionPackages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Profile> Profiles { get; set; }
      

    }
}
