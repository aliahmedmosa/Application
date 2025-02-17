using Application.DTOs.EntitiesDTOs.DepartmentDTOs.Validators;
using Application.Features.Department.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Department.Handlers.Command
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, BaseCommandResponse<string>>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var response = new BaseCommandResponse<string>();
            var validator = new DepartmentValidator();
            var validatorResult = await validator.ValidateAsync(request.DepartmentDTO, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed while update";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var oldDepartment = await _repository.GetAsync(request.DepartmentDTO.Id);
            var department = _mapper.Map(request.DepartmentDTO, oldDepartment);
            await _repository.UpdateAsync(department);
            response.Success = true;
            response.Message = "Successfuly update";
            response.Id = department.Id;
            response.Errors = null;
            return response;
        }
    }
}