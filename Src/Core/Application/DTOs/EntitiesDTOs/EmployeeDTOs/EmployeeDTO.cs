using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntitiesDTOs.EmployeeDTOs
{
    public class EmployeeDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
