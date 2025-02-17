using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Requests.Command
{
    public class UpdateEmployeeCommand : IRequest<BaseCommandResponse<string>>
    {
        public EmployeeDTO EmployeeDTO { get; set; }
    }
}
