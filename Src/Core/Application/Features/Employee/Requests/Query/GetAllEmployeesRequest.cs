using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Requests.Query
{
    public class GetAllEmployeesRequest : IRequest<BaseCommandResponse<List<EmployeeDTO>>>
    {
    }
}
