using Application.Features.Items.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Items.Handlers.Command
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Unit>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IItemRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(request.ItemDTO);
            await _repository.CreateAsync(item);
            return Unit.Value;
        }
    }
}
