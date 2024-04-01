using Application.Features.Items.Requests.Command;

namespace Application.Features.Items.Handlers.Command
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, BaseCommandResponse<string>>
    {
        private readonly IItemRepository _repository;

        public DeleteItemCommandHandler(IItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseCommandResponse<string>> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<string>();
            var oldItem = await _repository.GetAsync(request.Id);
            if (oldItem is null)
            {
                response.Success = false;
                response.Message = "No data found";
                response.Errors = null;
                return response;
            }
            //remove
            await _repository.DeleteAsync(oldItem.Id);
            response.Success = true;
            response.Message = "Item deleted";
            response.Errors = null;
            return response;
        }
    }
}
