﻿// <auto-generated />
using System;
using FitnessAppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitnessAppData.Migrations
{
    [DbContext(typeof(FitnessAppContext))]
    [Migration("20210212052142_updatedmigration")]
    partial class updatedmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FitnessAppData.Models.FitnessPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FitnessPackages");
                });

            modelBuilder.Entity("FitnessAppData.Models.FitnessSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FitnessDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FitnessTyoeId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FitnessTyoeId");

                    b.HasIndex("UserId");

                    b.ToTable("FitnessSchedules");
                });

            modelBuilder.Entity("FitnessAppData.Models.FitnessType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FitnessTypes");
                });

            modelBuilder.Entity("FitnessAppData.Models.NutritionPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NutritionPackages");
                });

            modelBuilder.Entity("FitnessAppData.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CardHolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PromotionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FitnessAppData.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("BMI")
                        .HasColumnType("real");

                    b.Property<float>("BodyFat")
                        .HasColumnType("real");

                    b.Property<string>("CurrentWorkoutPlan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<DateTime>("SleepTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WakeupTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<string>("WorkoutDietTarget")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("FitnessAppData.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FitnessPackageId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NutritionPackageId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FitnessPackageId");

                    b.HasIndex("NutritionPackageId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FitnessAppData.Models.FitnessSchedule", b =>
                {
                    b.HasOne("FitnessAppData.Models.FitnessType", "FitnessTyoe")
                        .WithMany()
                        .HasForeignKey("FitnessTyoeId");

                    b.HasOne("FitnessAppData.Models.User", null)
                        .WithMany("FitnessSchedules")
                        .HasForeignKey("UserId");

                    b.Navigation("FitnessTyoe");
                });

            modelBuilder.Entity("FitnessAppData.Models.Payment", b =>
                {
                    b.HasOne("FitnessAppData.Models.User", "User")
                        .WithOne("Payment")
                        .HasForeignKey("FitnessAppData.Models.Payment", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessAppData.Models.Profile", b =>
                {
                    b.HasOne("FitnessAppData.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("FitnessAppData.Models.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessAppData.Models.User", b =>
                {
                    b.HasOne("FitnessAppData.Models.FitnessPackage", "FitnessPackage")
                        .WithMany()
                        .HasForeignKey("FitnessPackageId");

                    b.HasOne("FitnessAppData.Models.NutritionPackage", "NutritionPackage")
                        .WithMany()
                        .HasForeignKey("NutritionPackageId");

                    b.Navigation("FitnessPackage");

                    b.Navigation("NutritionPackage");
                });

            modelBuilder.Entity("FitnessAppData.Models.User", b =>
                {
                    b.Navigation("FitnessSchedules");

                    b.Navigation("Payment");

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
