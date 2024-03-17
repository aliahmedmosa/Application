using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Requests.Command
{
    public class UpdateUomCommand:IRequest<Unit>
    {
        public UOMDTO UOMDTO { get; set; }
    }
}
