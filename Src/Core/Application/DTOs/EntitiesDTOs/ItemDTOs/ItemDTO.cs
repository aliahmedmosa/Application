using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntitiesDTOs.ItemDTOs
{
    public class ItemDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public int UOMId { get; set; }
    }
    
}
