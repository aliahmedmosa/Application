using Application.Features.UnitOfMeasurement.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Handlers.Command
{
    public class DeleteUOMCommandHandler : IRequestHandler<DeleteUOMCommand>
    {
        private readonly IUomRepository _repository;

        public DeleteUOMCommandHandler(IUomRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteUOMCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
