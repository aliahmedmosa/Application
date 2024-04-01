using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Requests.Command
{
    public class DeleteUOMCommand:IRequest<BaseCommandResponse<string>>
    {
        public int Id { get; set; }
    }
}
