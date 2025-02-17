using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Employee : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }
        //Navigtional prop
        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
