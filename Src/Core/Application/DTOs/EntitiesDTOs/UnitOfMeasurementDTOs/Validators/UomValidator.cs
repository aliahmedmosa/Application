global using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntitiesDTOs.UnitOfMeasurementDTOs.Validators
{
    public class UomValidator:AbstractValidator<UOMDTO>
    {
        public UomValidator()
        {
            RuleFor(x => x.Unit)
             .NotNull()
             .NotEmpty().WithMessage("{PropertyName} is required")
             .MinimumLength(3).WithMessage("{PropertyName} Limit with 3 charcture .")
             .MaximumLength(50).WithMessage("{PropertyName} Limit with 50 charcture .");
        }
    }
}
