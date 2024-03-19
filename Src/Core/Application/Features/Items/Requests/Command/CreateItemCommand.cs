using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Items.Requests.Command
{
    public class CreateItemCommand:IRequest<BaseCommandResponse>
    {
        public ItemDTO ItemDTO { get; set; }
    }
}
