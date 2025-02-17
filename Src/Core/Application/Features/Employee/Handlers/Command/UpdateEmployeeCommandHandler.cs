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
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseCommandResponse<string>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<string>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var response = new BaseCommandResponse<string>();
            var validator = new EmployeeValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.EmployeeDTO, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed while update";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var oldItem = await _repository.GetAsync(request.EmployeeDTO.Id);
            var item = _mapper.Map(request.EmployeeDTO, oldItem);
            await _repository.UpdateAsync(item);
            response.Success = true;
            response.Message = "Successfuly update";
            response.Id = item.Id;
            response.Errors = null;
            return response;
        }
    }
}
