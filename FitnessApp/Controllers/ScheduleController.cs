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
    [Route("api/Schedule")]
    public class ScheduleController : Controller
    {
        private IScheduleData _scheduleServuice;
        public ScheduleController(IScheduleData scheduleServuice) {
            _scheduleServuice = scheduleServuice;
        }

        [HttpGet]
        public IActionResult GetAllSchedules() {
            return Ok(_scheduleServuice.GetFitnessSchedules());
        }




        [HttpPost]
        public IActionResult AddSchedule([FromBody] Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSchedule = new FitnessSchedule()
            {
                FitnessDate = DateTime.Parse(schedule.FitnessDate),
                FitnessType=_scheduleServuice.GetFitnessTypeById(schedule.FitnessType),
                UserId=schedule.UserId
            };

            _scheduleServuice.AddScedule(newSchedule);

            return CreatedAtAction("GetUser", new {FitnessDate=schedule.FitnessDate  });
        }
    }
}
