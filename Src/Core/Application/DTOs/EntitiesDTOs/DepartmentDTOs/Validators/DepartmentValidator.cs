using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntitiesDTOs.DepartmentDTOs.Validators
{
    public class DepartmentValidator : AbstractValidator<DepartmentDTO>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Name)
             .NotNull()
             .NotEmpty().WithMessage("{PropertyName} is required")
             .MinimumLength(3).WithMessage("{PropertyName} Limit with 3 charcture .")
             .MaximumLength(50).WithMessage("{PropertyName} Limit with 50 charcture .");
        }
    }
}
