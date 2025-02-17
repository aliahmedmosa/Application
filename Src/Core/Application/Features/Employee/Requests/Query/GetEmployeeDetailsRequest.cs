using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Requests.Query
{
    public class GetEmployeeDetailsRequest : IRequest<BaseCommandResponse<EmployeeDTO>>
    {
        public int Id { get; set; }
    }
}
