using Application.DTOs.EntitiesDTOs.EmployeeDTOs;
using Application.Features.Employee.Requests.Command;
using Application.Features.Employee.Requests.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEmployees")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllEmployeesRequest());
            return Ok(response);
        }

        [HttpGet("GetEmployee/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetEmployeeDetailsRequest { Id = id });
            return Ok(response);
        }

        [HttpPost("AddEmployee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employeeDTO)
        {
            var response = await _mediator.Send(new CreateEmployeeCommand { EmployeeDTO = employeeDTO });
            return Ok(response);
        }

        [HttpPut("UpdateEmployee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] EmployeeDTO employeeDTO)
        {
            var response = await _mediator.Send(new UpdateEmployeeCommand { EmployeeDTO = employeeDTO });
            return Ok(response);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteEmployeeCommand { Id = id });
            return Ok(response);
        }
    }
}
