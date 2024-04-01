using Domain.Entities;

namespace Application.Features.Items.Handlers.Command
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, BaseCommandResponse<string>>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<string>> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            //Check validator
            var response = new BaseCommandResponse<string>();
            var validator = new ItemValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.ItemDTO, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed while update";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var oldItem = await _repository.GetAsync(request.ItemDTO.Id);
            var item = _mapper.Map(request.ItemDTO, oldItem);
            await _repository.UpdateAsync(item);
            response.Success = true;
            response.Message = "Successfuly update";
            response.Id = item.Id;
            response.Errors = null;
            return response;
        }
    }
}
