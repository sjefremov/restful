using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.ScheduleApi.WebApi.ViewModels.Validations
{
    public class AttendanceEditViewModelValidator : AbstractValidator<AttendanceEditViewModel>
    {
        public AttendanceEditViewModelValidator()
        {
            RuleFor(c => c.ScheduleId).GreaterThan(0).WithMessage("ScheduleId must be greater than 0");
        }
    }
}
