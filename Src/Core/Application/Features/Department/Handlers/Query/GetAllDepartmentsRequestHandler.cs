using Application.Features.Department.Requests.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Department.Handlers.Query
{
    public class GetAllDepartmentsRequestHandler : IRequestHandler<GetAllDepartmentsRequest, BaseCommandResponse<List<DepartmentDTO>>>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDepartmentsRequestHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<DepartmentDTO>>> Handle(GetAllDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<DepartmentDTO>>();
            var departments = await _repository.GetAllAsync();
            var result = _mapper.Map<List<DepartmentDTO>>(departments);
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
