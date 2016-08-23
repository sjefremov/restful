using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.ScheduleApi.Data.Repositories
{
    public class CourseRepository : EntityBaseRepository<Course>, ICourseRepository

    {

        public CourseRepository(ScheduleContext context) : base(context)

        {

        }

    }
}
