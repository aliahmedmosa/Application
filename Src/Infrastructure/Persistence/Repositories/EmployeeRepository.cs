using Application.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetAllAsyncWithInclude()
        => await _dbContext.Employees.AsNoTracking().Include(x => x.Department).ToListAsync();

        public async Task<bool> IsDepartmentExisting(int departmentId)
        {
            var response = await _dbContext.Departments.FindAsync(departmentId);
            return response != null;
        }
    }
}
