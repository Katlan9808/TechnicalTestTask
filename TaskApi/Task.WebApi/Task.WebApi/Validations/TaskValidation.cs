using FluentValidation;
using Task.Domain.Entities;
using Task.Models.Models;

namespace Task.WebApi.Validations
{
    public class TaskValidation : AbstractValidator<TaskDTO>
    {
        public TaskValidation()
        {
            RuleFor(x => x.Title).NotEmpty().Must(x => x.Length > 0).MaximumLength(20);
            RuleFor(x => x.Description).NotEmpty().Must(x => x.Length > 0).MaximumLength(100); 
            RuleFor(x => x.Developer).NotEmpty().Must(x => x.Length > 0).MaximumLength(20);
            RuleFor(x => x.State).NotEmpty().Must(x => x.Length > 0).MaximumLength(20);
        }
    }
}
