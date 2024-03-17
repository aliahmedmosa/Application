namespace Domain.Entities
{
    public class UOM : BaseEntity<int>
    {
        public string Unit { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}
