using Application.Features.Items.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Items.Handlers.Command
{
    internal class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IItemRepository _repository;

        public DeleteItemCommandHandler(IItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
