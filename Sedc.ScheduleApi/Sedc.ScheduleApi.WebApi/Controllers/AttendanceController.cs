using Microsoft.AspNetCore.Mvc;
using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Data.Repositories;
using Sedc.ScheduleApi.Model.Entities;
using Sedc.ScheduleApi.WebApi.ViewModels;
using System;
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

            var oldAttendances = _attRepository
                                    .FindBy(x => x.ScheduleId == att.ScheduleId)
                                    .ToList();
            if (oldAttendances.Any())
            {
                var deleteStudents = oldAttendances
                                            .Select(a => a.StudentId)
                                            .Except(att.StudentIds)
                                            .ToList();

                if (deleteStudents.Any())
                {
                    _attRepository.DeleteWhere(a => a.ScheduleId == att.ScheduleId && deleteStudents.Contains(a.StudentId));
                    _attRepository.Commit();
                }
            }

            var newStudents = att.StudentIds.Except(oldAttendances.Select(a => a.StudentId));

            newStudents.ToList()
                        .ForEach(sId => 
                                        {
                                            var newAtt = new Attendance
                                            {
                                                ScheduleId = att.ScheduleId,
                                                StudentId = sId
                                            };

                                            _attRepository.Add(newAtt);

                                        }
                                );
            
           _attRepository.Commit();

            return Ok();
        }
    }
}
