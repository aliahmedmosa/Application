using Application.Features.UnitOfMeasurement.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Features.UnitOfMeasurement.Handlers.Command
{
    public class CreateUOMCommandHandler : IRequestHandler<CreateUOMCommand, Unit>
    {
        private readonly IUomRepository _repository;
        private readonly IMapper _mapper;

        public CreateUOMCommandHandler(IUomRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateUOMCommand request, CancellationToken cancellationToken)
        {
            var Uom = _mapper.Map<UOM>(request.UOMDTO);
            await _repository.CreateAsync(Uom);
            return Unit.Value;
        }
    }
}
