using Microsoft.AspNetCore.Mvc;
using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Data.Repositories;
using Sedc.ScheduleApi.Model.Entities;
using Sedc.ScheduleApi.WebApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sedc.ScheduleApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AttendanceController : Controller
    {
        private IAttendanceRepository _attRepository;

        public AttendanceController(IAttendanceRepository attRepository)
        {
            _attRepository = attRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody]AttendanceViewModel att)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var found = _attRepository.FindBy(x => x.StudentId == att.StudentId && x.ScheduleId == att.ScheduleId);
            if (found.Any())
            {
                return BadRequest("Attendance already created");
            }

            Attendance newAtt = new Attendance
            {
                ScheduleId = att.ScheduleId,
                StudentId = att.StudentId
            };

            _attRepository.Add(newAtt);
            _attRepository.Commit();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody]AttendanceEditViewModel att)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldAttendances = _attRepository.FindBy(x => x.ScheduleId == att.ScheduleId);
            if (oldAttendances.Any())
            {
                var deleteAttendances = oldAttendances.Select(a => a.StudentId).Except(att.StudentIds);
                //TODO continue here...
            }

            Attendance newAtt = new Attendance
            {
                ScheduleId = att.ScheduleId,
                StudentId = att.StudentId
            };

            _attRepository.Add(newAtt);
            _attRepository.Commit();

            return Ok();
        }
    }
}
