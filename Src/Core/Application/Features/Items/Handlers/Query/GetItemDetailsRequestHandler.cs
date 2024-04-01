namespace Application.Features.Items.Handlers.Query
{
    public class GetItemDetailsRequestHandler : IRequestHandler<GetItemDetailsRequest, BaseCommandResponse<ItemDTO>>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public GetItemDetailsRequestHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<ItemDTO>> Handle(GetItemDetailsRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<ItemDTO>();
            var item = await _repository.GetAsync(request.Id);
            ItemDTO result = _mapper.Map<ItemDTO>(item);
            if (item is null)
            {
                response.Success = false;
                response.Message = "Data not found";
                response.Data= null;
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
