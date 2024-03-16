using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Handlers.Query
{
    internal class GetUOMDetailsRequestHandler : IRequestHandler<GetUOMDetailsRequest, UnitOfMeasurementDTO>
    {
        private readonly IUnitOfmeasurementRepository _repository;
        private readonly IMapper _mapper;

        public GetUOMDetailsRequestHandler(IUnitOfmeasurementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UnitOfMeasurementDTO> Handle(GetUOMDetailsRequest request, CancellationToken cancellationToken)
        {
            var UOM = await _repository.GetAsync(request.Id);
            if (UOM is null)
                throw new Exception();
            return _mapper.Map<UnitOfMeasurementDTO>(UOM);
            
        }
    }
}
