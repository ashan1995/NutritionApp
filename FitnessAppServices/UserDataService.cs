using FitnessAppData;
using FitnessAppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FitnessAppServices
{
    public class UserDataService : IUserData
    {
        private FitnessAppContext _dbcontext;
        private readonly AppSettings _appSettings;

        public UserDataService(FitnessAppContext dbcontext, IOptions<AppSettings> appSettings) {
            _dbcontext = dbcontext;
            _appSettings = appSettings.Value;
        }

        public void Add(User newUser)
        {
            _dbcontext.Add(newUser);
            _dbcontext.SaveChanges();
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {

            var user = _dbcontext.Users.FirstOrDefault(user=>(user.Email==model.Email && user.Password==model.Password) );

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbcontext.Users
                .Include(assets=>assets.NutritionPackage)
                .Include(assets=>assets.FitnessPackage);
        }

        public User GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(asset=>asset.Id==id);
        }

        public string GetEmail(int id)
        {
            return GetById(id).Email;
        }

        public string GetFirstName(int id)
        {
            return GetById(id).FirstName;
        }

        public FitnessPackage GetFitnessPackage(int id)
        {
            return _dbcontext.FitnessPackages.FirstOrDefault(asset=>asset.Id==id);
        }

        public string GetLastName(int id)
        {
            return GetById(id).LastName;
        }

        public NutritionPackage GetNutritionPackage(int id)
        {
            return _dbcontext.NutritionPackages.FirstOrDefault(asset => asset.Id == id);
        }

        public Payment GetPaymentInfo(int id)
        {
            return GetById(id).Payment;
        }

        public Profile GetProfileData(int id)
        {
            return GetById(id).Profile;
        }

        public IEnumerable<FitnessSchedule> GetSchedules(int id)
        {
            return GetById(id).FitnessSchedules;
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

      
    }
}
