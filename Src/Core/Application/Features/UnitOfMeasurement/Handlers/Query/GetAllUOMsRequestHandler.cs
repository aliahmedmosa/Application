using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Handlers.Query
{
    public class GetAllUOMsRequestHandler : IRequestHandler<GetAllUOMsRequest, List<UnitOfMeasurementDTO>>
    {
        private readonly IUnitOfmeasurementRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUOMsRequestHandler(IUnitOfmeasurementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<UnitOfMeasurementDTO>> Handle(GetAllUOMsRequest request, CancellationToken cancellationToken)
        {
            var UOMs = await _repository.GetAllAsync();
            var result = _mapper.Map<List<UnitOfMeasurementDTO>>(UOMs);
            return result;
        }
    }
}
