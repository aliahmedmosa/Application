using Application.Features.Department.Requests.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Department.Handlers.Query
{
    public class GetDepartmentDetailsRequestHandler : IRequestHandler<GetDepartmentDetailsRequest, BaseCommandResponse<DepartmentDTO>>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public GetDepartmentDetailsRequestHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<DepartmentDTO>> Handle(GetDepartmentDetailsRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<DepartmentDTO>();
            var department = await _repository.GetAsync(request.Id);
            var result = _mapper.Map<DepartmentDTO>(department);
            if (department is null)
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