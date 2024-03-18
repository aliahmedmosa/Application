using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntitiesDTOs.UnitOfMeasurementDTOs
{
    public class UOMDTO : BaseDTO<int>
    {
        public string Unit { get; set; }
        public string Description { get; set; }
    }
}
