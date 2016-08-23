using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.ScheduleApi.Model.Entities
{
    public class Attendance : IEntityBase
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ScheduleId { get; set; }

        public Student Student { get; set; }

        public Schedule Schedule { get; set; }
    }
}
