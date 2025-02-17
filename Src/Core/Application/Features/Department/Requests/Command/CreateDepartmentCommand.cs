using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Department.Requests.Command
{
    public class CreateDepartmentCommand: IRequest<BaseCommandResponse<string>>
    {
        public DepartmentDTO DepartmentDTO { get; set; }
    }
}
