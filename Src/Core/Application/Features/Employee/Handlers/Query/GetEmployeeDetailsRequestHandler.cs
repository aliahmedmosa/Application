using Application.Features.Employee.Requests.Query;
using Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Handlers.Query
{
    public class GetEmployeeDetailsRequestHandler : IRequestHandler<GetEmployeeDetailsRequest, BaseCommandResponse<EmployeeDTO>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        public GetEmployeeDetailsRequestHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<EmployeeDTO>> Handle(GetEmployeeDetailsRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<EmployeeDTO>();
            var employee = await _repository.GetAsync(request.Id);
            EmployeeDTO result = _mapper.Map<EmployeeDTO>(employee);
            if (employee is null)
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
