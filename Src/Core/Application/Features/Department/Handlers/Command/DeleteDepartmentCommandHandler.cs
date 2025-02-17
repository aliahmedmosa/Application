using Application.Features.Department.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Department.Handlers.Command
{
    internal class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, BaseCommandResponse<string>>
    {
        private readonly IDepartmentRepository _repository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseCommandResponse<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<string>();
            var oldDepartment = await _repository.GetAsync(request.Id);
            if (oldDepartment is null)
            {
                response.Success = false;
                response.Message = "No data found";
                response.Errors = null;
                return response;
            }
            //remove
            await _repository.DeleteAsync(oldDepartment.Id);
            response.Success = true;
            response.Message = "Department deleted";
            response.Errors = null;
            return response;
        }
    }
}