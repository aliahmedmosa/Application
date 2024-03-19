using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Handlers.Query
{
    public class GetUOMDetailsRequestHandler : IRequestHandler<GetUOMDetailsRequest, UOMDTO>
    {
        private readonly IUomRepository _repository;
        private readonly IMapper _mapper;

        public GetUOMDetailsRequestHandler(IUomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UOMDTO> Handle(GetUOMDetailsRequest request, CancellationToken cancellationToken)
        {
            var UOM = await _repository.GetAsync(request.Id);
            if (UOM is null)
                throw new Exception();
            return _mapper.Map<UOMDTO>(UOM);
            
        }
    }
}
