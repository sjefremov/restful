using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.WebApi.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sedc.ScheduleApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {

        private IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        // GET: api/values
        [HttpGet("{id}/attendances", Name = "GetScheduleAttendances")]
        public IActionResult GetAttendances(int id)
        {
            var schedule = _scheduleRepository.GetSingle(s => s.Id == id, s => s.Attendances);

            if (schedule == null)
            {
                return NotFound();
            }

            var attendances = schedule.Attendances;

            var attendancesVM = attendances.Select
                (
                    a => new AttendanceViewModel
                    {
                        Id = a.Id,
                        ScheduleId = a.ScheduleId,
                        StudentId = a.StudentId
                    }
                );

            return new OkObjectResult(attendancesVM);
        }

        
    }
}
