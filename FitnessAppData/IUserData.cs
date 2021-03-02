using FitnessApp.Models;
using FitnessAppData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppData
{
    public interface IUserData
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(Register newUser, string origin);
        string GetFirstName(int id);
        string GetLastName(int id);
        string GetEmail(int id);

        FitnessPackage GetFitnessPackage(int id);

        NutritionPackage GetNutritionPackage(int id);

        Payment GetPaymentInfo(int id);

        Profile GetProfileData(int id);

        IEnumerable<FitnessSchedule> GetSchedules(int id);

        AuthenticateResponse Authenticate(AuthenticateRequest model);

        void ForgetPassword();

        void VerifyAccount();

    }
}
