using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntitiesDTOs.ItemDTOs.Validators
{
    public class ItemValidator : AbstractValidator<ItemDTO>
    {
        public ItemValidator(IItemRepository repository)
        {
            RuleFor(x => x.Name)
             .NotNull()
             .NotEmpty().WithMessage("{PropertyName} is required")
             .MinimumLength(3).WithMessage("{PropertyName} Limit with {ComprisonValue} charcture .")
             .MaximumLength(50).WithMessage("{PropertyName} Limit with {ComprisonValue} charcture .");
            RuleFor(x => x.UOMId)
                .MustAsync(async (id, token) =>
                {
                    var uomIdIsExisting = await repository.IsUomExisting(id);
                    return uomIdIsExisting;
                })
                .WithMessage("{PropertyName} is not existing");
                
        }
    }
}
