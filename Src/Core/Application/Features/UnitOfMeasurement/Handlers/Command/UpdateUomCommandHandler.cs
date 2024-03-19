namespace Application.Features.UnitOfMeasurement.Handlers.Command
{
    public class UpdateUomCommandHandler : IRequestHandler<UpdateUomCommand, Unit>
    {
        private readonly IUomRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUomCommandHandler(IUomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUomCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var validator = new UomValidator();
            var validatorResult = await validator.ValidateAsync(request.UOMDTO, cancellationToken);
            if (validatorResult.IsValid == false)
                throw new Exceptions.ValidationException(validatorResult);

            var oldUom = await _repository.GetAsync(request.UOMDTO.Id);
            var res = _mapper.Map(request.UOMDTO, oldUom);
            await _repository.UpdateAsync(res);
            return Unit.Value;
        }
    }
}
