using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Handlers.Query
{
    public class GetUOMDetailsRequestHandler : IRequestHandler<GetUOMDetailsRequest, BaseCommandResponse<UOMDTO>>
    {
        private readonly IUomRepository _repository;
        private readonly IMapper _mapper;

        public GetUOMDetailsRequestHandler(IUomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<UOMDTO>> Handle(GetUOMDetailsRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<UOMDTO>();
            var uOM = await _repository.GetAsync(request.Id);
            var result = _mapper.Map<UOMDTO>(uOM);
            if (uOM is null)
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
