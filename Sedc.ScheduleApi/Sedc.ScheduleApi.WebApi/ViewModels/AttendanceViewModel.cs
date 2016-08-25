using Sedc.ScheduleApi.WebApi.ViewModels.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sedc.ScheduleApi.WebApi.ViewModels
{
    public class AttendanceViewModel : IValidatableObject
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ScheduleId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new AttendanceViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
