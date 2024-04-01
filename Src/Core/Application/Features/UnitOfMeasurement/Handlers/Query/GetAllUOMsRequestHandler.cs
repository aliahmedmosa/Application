using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Handlers.Query
{
    public class GetAllUOMsRequestHandler : IRequestHandler<GetAllUOMsRequest, BaseCommandResponse<List<UOMDTO>>>
    {
        private readonly IUomRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUOMsRequestHandler(IUomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<UOMDTO>>> Handle(GetAllUOMsRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<UOMDTO>>();
            var UOMs = await _repository.GetAllAsync();
            var result = _mapper.Map<List<UOMDTO>>(UOMs);
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
