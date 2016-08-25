using FluentValidation;

namespace Sedc.ScheduleApi.WebApi.ViewModels.Validations
{
    public class AttendanceViewModelValidator : AbstractValidator<AttendanceViewModel>
    {
        public AttendanceViewModelValidator()
        {
            RuleFor(c => c.ScheduleId).GreaterThan(0).WithMessage("ScheduleId must be greater than 0");
            RuleFor(c => c.StudentId).GreaterThan(0).WithMessage("StudentId must be greater than 0");
        }
    }
}
