namespace Application.Features.Items.Handlers.Query
{
    public class GetItemDetailsRequestHandler : IRequestHandler<GetItemDetailsRequest, ItemDTO>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public GetItemDetailsRequestHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ItemDTO> Handle(GetItemDetailsRequest request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetAsync(request.Id);
            if (item is null)
                throw new Exception();
            return _mapper.Map<ItemDTO>(item);
        }
    }
}
