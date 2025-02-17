using Application.Features.Employee.Requests.Command;
using Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Handlers.Command
{
    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseCommandResponse<string>>
    {
        private readonly IEmployeeRepository _repository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseCommandResponse<string>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<string>();
            var oldEmployee = await _repository.GetAsync(request.Id);
            if (oldEmployee is null)
            {
                response.Success = false;
                response.Message = "No data found";
                response.Errors = null;
                return response;
            }
            //remove
            await _repository.DeleteAsync(oldEmployee.Id);
            response.Success = true;
            response.Message = "Item deleted";
            response.Errors = null;
            return response;
        }
    }
}