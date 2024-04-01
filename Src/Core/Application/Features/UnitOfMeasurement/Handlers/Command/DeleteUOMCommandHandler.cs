namespace Application.Features.UnitOfMeasurement.Handlers.Command
{
    public class DeleteUOMCommandHandler : IRequestHandler<DeleteUOMCommand, BaseCommandResponse<string>>
    {
        private readonly IUomRepository _repository;

        public DeleteUOMCommandHandler(IUomRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseCommandResponse<string>> Handle(DeleteUOMCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<string>();
            var oldUom = await _repository.GetAsync(request.Id);
            if (oldUom is null)
            {
                response.Success = false;
                response.Message = "No data found";
                response.Errors = null;
                return response;
            }
            //remove
            await _repository.DeleteAsync(oldUom.Id);
            response.Success = true;
            response.Message = "UOM deleted";
            response.Errors = null;
            return response;
        }
    }
}
