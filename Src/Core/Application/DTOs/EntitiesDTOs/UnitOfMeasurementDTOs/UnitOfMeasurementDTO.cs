﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntitiesDTOs.UnitOfMeasurementDTOs
{
    public class UnitOfMeasurementDTO : BaseDTO<int>
    {
        public string UOM { get; set; }
        public string Description { get; set; }
    }
}
