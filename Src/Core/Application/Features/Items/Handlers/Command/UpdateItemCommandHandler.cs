using Application.Features.Items.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Items.Handlers.Command
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Unit>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IItemRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var oldItem = await _repository.GetAsync(request.ItemDTO.Id);
            var res = _mapper.Map(request.ItemDTO, oldItem);
            await _repository.UpdateAsync(res);
            return Unit.Value;
        }
    }
}
