using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        //Special For Item
        Task<List<Employee>> GetAllAsyncWithInclude();
        Task<bool> IsDepartmentExisting(int departmentId);
    }
}
