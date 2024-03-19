using Application.Features.Items.Requests.Command;

namespace Application.Features.Items.Handlers.Command
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IItemRepository _repository;

        public DeleteItemCommandHandler(IItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var oldItem = await _repository.GetAsync(request.Id);
            if (oldItem is null)
                throw new NotFoundException(nameof(Item),request.Id);
            //remove
            await _repository.DeleteAsync(oldItem.Id);
            return Unit.Value;
        }
    }
}
