using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.EntitiesDTOs.ItemDTOs
{
    public class ItemDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int QTY { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int UOMId { get; set; }
    }

}
