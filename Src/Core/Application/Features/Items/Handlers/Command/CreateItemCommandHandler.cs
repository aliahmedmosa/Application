namespace Application.Features.Items.Handlers.Command
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, BaseCommandResponse<string>>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<string>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var response = new BaseCommandResponse<string>();
            var validator = new ItemValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.ItemDTO, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed while creation";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var item = _mapper.Map<Item>(request.ItemDTO);
            await _repository.CreateAsync(item);
            response.Success = true;
            response.Message = "Successfuly creation";
            response.Id = item.Id;
            response.Errors = null;
            return response;
        }
    }
}
