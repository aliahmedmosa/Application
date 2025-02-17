namespace Domain.Entities
{
    public class Department : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
