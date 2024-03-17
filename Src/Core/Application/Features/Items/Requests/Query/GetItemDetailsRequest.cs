using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Items.Requests.Query
{
    public class GetItemDetailsRequest:IRequest<ItemDTO>
    {
        public int Id { get; set; }
    }
}
