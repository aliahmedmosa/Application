using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Department.Requests.Query
{
    public class GetDepartmentDetailsRequest : IRequest<BaseCommandResponse<DepartmentDTO>>
    {
        public int Id { get; set; }
    }
}

