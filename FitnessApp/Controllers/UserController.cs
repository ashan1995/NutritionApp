using FitnessApp.Models;
using FitnessAppData;
using FitnessAppData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private IUserData _userData;

        public UserController(IUserData userData) {
            _userData = userData;
        }
        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
      
            return Ok(_userData.GetById(id));
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _userData.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }



        [HttpPost]
        public IActionResult Register([FromBody] Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                DOB = register.DOB,
                Email = register.Email,
                Password = register.Password,
                Gender = register.Gender,
                TelNo = register.TelNo,
                FitnessPackage = _userData.GetFitnessPackage(register.FitnessPackage),
                NutritionPackage = _userData.GetNutritionPackage(register.NutritionPackage)
            };
            _userData.Add(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
    }
}
