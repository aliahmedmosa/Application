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
            var oldUom = await _repository.GetAsync(request.Id);
            if (oldUom is null)
                throw new NotFoundException(nameof(UOM), request.Id);
            //Remove
            await _repository.DeleteAsync(oldUom.Id);
            return Unit.Value;
        }
    }
}
