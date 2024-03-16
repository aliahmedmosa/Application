using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitOfMeasurement.Requests.Query
{
    public class GetUOMDetailsRequest:IRequest<UnitOfMeasurementDTO>
    {
        public int Id { get; set; }
    }
}
