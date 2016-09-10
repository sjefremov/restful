using Sedc.ScheduleApi.WebApi.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.ScheduleApi.WebApi.ViewModels
{
    public class AttendanceEditViewModel : IValidatableObject
    {
        
        public int[] StudentIds { get; set; }

        public int ScheduleId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new AttendanceEditViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
