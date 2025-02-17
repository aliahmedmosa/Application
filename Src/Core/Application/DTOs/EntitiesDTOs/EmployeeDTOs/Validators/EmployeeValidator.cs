using Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntitiesDTOs.EmployeeDTOs.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator(IEmployeeRepository repository)
        {
            RuleFor(x => x.Name)
             .NotNull()
             .NotEmpty().WithMessage("{PropertyName} is required")
             .MinimumLength(3).WithMessage("{PropertyName} Limit with {ComprisonValue} charcture .")
             .MaximumLength(50).WithMessage("{PropertyName} Limit with {ComprisonValue} charcture .");
            RuleFor(x => x.DepartmentId)
                .MustAsync(async (id, token) =>
                {
                    var uomIdIsExisting = await repository.IsDepartmentExisting(id);
                    return uomIdIsExisting;
                })
                .WithMessage("{PropertyName} is not existing");

        }
    }
}
