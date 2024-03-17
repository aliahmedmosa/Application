using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class UnitOfMeasurementMappingProfile:Profile
    {
        public UnitOfMeasurementMappingProfile()
        {
                //Configure Automapper
                CreateMap<UOM, UOMDTO>().ReverseMap();
        }
    }
}
