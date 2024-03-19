namespace Application.Features.Items.Handlers.Command
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Unit>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var validator = new ItemValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.ItemDTO, cancellationToken);
            if (validatorResult.IsValid == false)
                throw new Exceptions.ValidationException(validatorResult);

            var oldItem = await _repository.GetAsync(request.ItemDTO.Id);
            var res = _mapper.Map(request.ItemDTO, oldItem);
            await _repository.UpdateAsync(res);
            return Unit.Value;
        }
    }
}
