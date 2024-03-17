using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Handlers.Query
{
    public class GetAllUOMsRequestHandler : IRequestHandler<GetAllUOMsRequest, List<UOMDTO>>
    {
        private readonly IUomRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUOMsRequestHandler(IUomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<UOMDTO>> Handle(GetAllUOMsRequest request, CancellationToken cancellationToken)
        {
            var UOMs = await _repository.GetAllAsync();
            var result = _mapper.Map<List<UOMDTO>>(UOMs);
            return result;
        }
    }
}
