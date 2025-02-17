using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Requests.Command
{
    public class DeleteEmployeeCommand : IRequest<BaseCommandResponse<string>>
    {
        public int Id { get; set; }
    }
}
