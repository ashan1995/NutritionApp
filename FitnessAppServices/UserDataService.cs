using FitnessApp.Models;
using FitnessAppData;
using FitnessAppData.Models;
using FitnessAppServices.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using FitnessAppData.Models.HelperModels;

namespace FitnessAppServices
{
    public class UserDataService : IUserData
    {
        private FitnessAppContext _dbcontext;
        private readonly AppSettings _appSettings;
        private IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private LinkGenerator _linkGenerator;

        public UserDataService(FitnessAppContext dbcontext, IOptions<AppSettings> appSettings,IEmailService emailService, IHttpContextAccessor httpContextAccessor,LinkGenerator linkGenerator) {
            _dbcontext = dbcontext;
            _appSettings = appSettings.Value;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _linkGenerator = linkGenerator;
          
        }

        public void Add(Register newUser, string origin)
        {
            if (_dbcontext.Users.Any(x => x.Email == newUser.Email))
            {
                // send already registered error in email to prevent account enumeration
                sendAlreadyRegisteredEmail(newUser.Email, origin);
                return;
            }
           
            var user = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                DOB = newUser.DOB,
                Email = newUser.Email,
                Password = newUser.Password,
                Gender = newUser.Gender,
                TelNo = newUser.TelNo,
                FitnessPackage = this.GetFitnessPackage(newUser.FitnessPackage),
                NutritionPackage = GetNutritionPackage(newUser.NutritionPackage),
                Created = DateTime.UtcNow,
                VerificationToken = randomTokenString()
        };

           
            _dbcontext.Add(user);
            _dbcontext.SaveChanges();

            sendVerificationEmail(user, origin);
        }

        public void VerifyEmail(string token)
        {
            var account = _dbcontext.Users.SingleOrDefault(x => x.VerificationToken == token);

            if (account == null) throw new AppException("Verification failed");

            account.Verified = DateTime.UtcNow;
            account.VerificationToken = null;

            _dbcontext.Users.Update(account);
            _dbcontext.SaveChanges();
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {

            var user = _dbcontext.Users.FirstOrDefault(user=>(user.Email==model.Email && user.Password==model.Password) );

            // return null if user not found
            if (user == null || !user.IsVerified) return null;

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
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var account = _dbcontext.Users.SingleOrDefault(x => x.Email == model.Email);

            // always return ok response to prevent email enumeration
            if (account == null) return;

            // create reset token that expires after 1 day
            account.ResetToken = randomTokenString();
            account.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

            _dbcontext.Users.Update(account);
            _dbcontext.SaveChanges();

            // send email
            sendPasswordResetEmail(account, origin);
        }

        public void ResetPassword(PasswordResetRequest model)
        {
            var account = _dbcontext.Users.SingleOrDefault(x =>
                x.ResetToken == model.Token &&
                x.ResetTokenExpires > DateTime.UtcNow);

            if (account == null)
                throw new AppException("Invalid token");

            // update password and remove reset token
            account.Password = model.Password;
            account.PasswordReset = DateTime.UtcNow;
            account.ResetToken = null;
            account.ResetTokenExpires = null;

            _dbcontext.Users.Update(account);
            _dbcontext.SaveChanges();
        }


        public void VerifyAccount()
        {

            throw new NotImplementedException();
        }

        private string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
        private void sendAlreadyRegisteredEmail(string email, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
                message = $@"<p>If you don't know your password please visit the <a href=""{origin}/account/forgot-password"">forgot password</a> page.</p>";
            else
                message = "<p>If you don't know your password you can reset it via the <code>/accounts/forgot-password</code> api route.</p>";

            _emailService.Send(
                to: email,
                subject: "Sign-up Verification API - Email Already Registered",
                html: $@"<h4>Email Already Registered</h4>
                         <p>Your email <strong>{email}</strong> is already registered.</p>
                         {message}"
            );
        }
        private void sendVerificationEmail(User account, string origin)
        {
            string message;
            
   
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/api/user/verify-email?token={account.VerificationToken }";
                message = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            }
            else
            {

                var url = _linkGenerator.GetUriByAction(_httpContextAccessor.HttpContext,
                    action: "VerifyEmail",
                    controller:"User",
                    values: new { token=account.VerificationToken }
                );
                
                message = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{url}"">{url}</a></p>";
            }

            _emailService.Send(
                to: account.Email,
                subject: "Sign-up Verification API - Verify Email",
                html: $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {message}"
            );
        }

        private void sendPasswordResetEmail(User account, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var resetUrl = $"{origin}/api/user/reset-password?token={account.ResetToken}";
                message = $@"<p>Please click the below link to reset your password, the link will be valid for 1 day:</p>
                             <p><a href=""{resetUrl}"">{resetUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Please use the below token to reset your password with the <code>/accounts/reset-password</code> api route:</p>
                             <p><code>{account.ResetToken}</code></p>";
            }

            _emailService.Send(
                to: account.Email,
                subject: "Sign-up Verification API - Reset Password",
                html: $@"<h4>Reset Password Email</h4>
                         {message}"
            );
        }
    }
}
