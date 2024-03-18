using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Item : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }

        //Navigtional prop
        public virtual UOM UOM { get; set; }     
        public int UOMId { get; set; }

    }
}
