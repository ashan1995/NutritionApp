using FitnessApp.Models;
using FitnessAppData;
using FitnessAppData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        [HttpGet("getall")]
        public IActionResult GetAll() {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            return Ok(_userData.GetAll());

        }



        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userName = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return Ok(_userData.GetById(userName));
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

        [HttpGet("fitnessschedules/{id}")]
        public IActionResult FitnessSchedules([FromRoute] int id) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_userData.GetSchedules(id));
        }




        [HttpPost]
        public IActionResult Register([FromBody] Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userData.Add(register, Request.Headers["origin"]);

            return CreatedAtAction("GetUser", new { id = register.FirstName }, register);
        }
    }
}
