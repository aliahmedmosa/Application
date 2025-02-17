using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Department.Requests.Command
{
    public class DeleteDepartmentCommand : IRequest<BaseCommandResponse<string>>
    {
        public int Id { get; set; }
    }
}