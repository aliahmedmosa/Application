using Domain.Entities;

namespace Application.Features.Items.Handlers.Query
{
    public class GetAllItemsRequestHandler : IRequestHandler<GetAllItemsRequest, BaseCommandResponse<List<ItemDTO>>>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public GetAllItemsRequestHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<ItemDTO>>> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<ItemDTO>>();
            var items = await _repository.GetAllAsync();
            var result = _mapper.Map<List<ItemDTO>>(items);
            if (result is null)
            {
                response.Success = false;
                response.Message = "Data not found";
                response.Data = null;
                response.Errors = null;
                return response;
            }
            response.Success = true;
            response.Message = "Data obtained successfuly";
            response.Data = result;
            response.Errors = null;
            return response;
        }
    }
}
