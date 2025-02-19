using Application.Features.Employee.Requests.Query;
using Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Handlers.Query
{
    public class GetAllEmployeesRequestHandler : IRequestHandler<GetAllEmployeesRequest, BaseCommandResponse<List<EmployeeDTO>>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        public GetAllEmployeesRequestHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<EmployeeDTO>>> Handle(GetAllEmployeesRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<EmployeeDTO>>();
            var employees = await _repository.GetAllAsync();
            var result = _mapper.Map<List<EmployeeDTO>>(employees);
            if (result is null)
            {
                response.Success = false;
                response.Message = "Data not found";
                response.Data = null;
                response.Errors = null;
                return response;
            }
            response.Success = true;
            response.Message = "Data obtained successfuly";
            response.Data = result;
            response.Errors = null;
            return response;
        }
    }
}
