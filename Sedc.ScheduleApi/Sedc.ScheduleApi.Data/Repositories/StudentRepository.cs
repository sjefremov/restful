using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.ScheduleApi.Data.Repositories
{
    public class StudentRepository : EntityBaseRepository<Student>, IStudentRepository

    {

        public StudentRepository(ScheduleContext context) : base(context)

        {

        }

    }
}
