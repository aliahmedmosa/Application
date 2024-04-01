namespace Application.Features.UnitOfMeasurement.Handlers.Command
{
    public class UpdateUomCommandHandler : IRequestHandler<UpdateUomCommand, BaseCommandResponse<string>>
    {
        private readonly IUomRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUomCommandHandler(IUomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<string>> Handle(UpdateUomCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var response = new BaseCommandResponse<string>();
            var validator = new UomValidator();
            var validatorResult = await validator.ValidateAsync(request.UOMDTO, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed while update";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var oldUOM = await _repository.GetAsync(request.UOMDTO.Id);
            var uOM = _mapper.Map(request.UOMDTO, oldUOM);
            await _repository.UpdateAsync(uOM);
            response.Success = true;
            response.Message = "Successfuly update";
            response.Id = uOM.Id;
            response.Errors = null;
            return response;
        }
    }
}
