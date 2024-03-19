namespace Application.Features.UnitOfMeasurement.Handlers.Command
{
    public class CreateUOMCommandHandler : IRequestHandler<CreateUOMCommand, BaseCommandResponse>
    {
        private readonly IUomRepository _repository;
        private readonly IMapper _mapper;

        public CreateUOMCommandHandler(IUomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateUOMCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var response = new BaseCommandResponse();
            var validator = new UomValidator();
            var validatorResult = await validator.ValidateAsync(request.UOMDTO, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed while creation";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var Uom = _mapper.Map<UOM>(request.UOMDTO);
            await _repository.CreateAsync(Uom);
            response.Success = true;
            response.Message = "Successfuly creation";
            response.Id = request.UOMDTO.Id;
            return response;
        }
    }
}
