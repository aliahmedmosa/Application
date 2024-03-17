using Application.Features.UnitOfMeasurement.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Handlers.Command
{
    public class UpdateUomCommandHandler : IRequestHandler<UpdateUomCommand, Unit>
    {
        private readonly IUomRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUomCommandHandler(IUomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUomCommand request, CancellationToken cancellationToken)
        {
            var oldUom=await _repository.GetAsync(request.UOMDTO.Id);
            var res = _mapper.Map(request.UOMDTO, oldUom);
            await _repository.UpdateAsync(res);
            return Unit.Value;
        }
    }
}
