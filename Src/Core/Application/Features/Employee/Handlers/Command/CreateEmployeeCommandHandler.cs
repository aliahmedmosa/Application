using Application.DTOs.EntitiesDTOs.EmployeeDTOs.Validators;
using Application.Features.Employee.Requests.Command;
using Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Handlers.Command
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseCommandResponse<string>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;


        public CreateEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<string>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var response = new BaseCommandResponse<string>();
            var validator = new EmployeeValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.EmployeeDTO, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed while creation";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var employ = _mapper.Map<Domain.Entities.Employee>(request.EmployeeDTO);
            await _repository.CreateAsync(employ);
            response.Success = true;
            response.Message = "Successfuly creation";
            response.Id = employ.Id;
            response.Errors = null;
            return response;
        }
    }
}