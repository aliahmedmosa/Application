using Application.Features.Items.Requests.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Items.Handlers.Query
{
    public class GetAllItemsRequestHandler : IRequestHandler<GetAllItemsRequest, List<ItemDTO>>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public GetAllItemsRequestHandler(IItemRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ItemDTO>> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllAsync();
            var result = _mapper.Map<List<ItemDTO>>(items);
            return result;
        }
    }
}
