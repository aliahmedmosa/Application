using Application.DTOs.EntitiesDTOs.DepartmentDTOs.Validators;
using Application.Features.Department.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Department.Handlers.Command
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BaseCommandResponse<string>>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var response = new BaseCommandResponse<string>();
            var validator = new DepartmentValidator();
            var validatorResult = await validator.ValidateAsync(request.DepartmentDTO, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed while creation";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var department = _mapper.Map<Domain.Entities.Department>(request.DepartmentDTO);
            await _repository.CreateAsync(department);
            response.Success = true;
            response.Message = "Successfuly creation";
            response.Id = department.Id;
            return response;
        }
    }
}
