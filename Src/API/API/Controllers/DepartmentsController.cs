using Application.DTOs.EntitiesDTOs.DepartmentDTOs;
using Application.DTOs.EntitiesDTOs.UnitOfMeasurementDTOs;
using Application.Features.Department.Requests.Command;
using Application.Features.Department.Requests.Query;
using Application.Features.UnitOfMeasurement.Requests.Command;
using Application.Features.UnitOfMeasurement.Requests.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllDepartments")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllDepartmentsRequest());
            return Ok(response);
        }

        [HttpGet("GetDepartment/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetDepartmentDetailsRequest { Id = id });
            return Ok(response);
        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> Post([FromBody] DepartmentDTO departmentDTO)
        {
            var response = await _mediator.Send(new CreateDepartmentCommand { DepartmentDTO = departmentDTO });
            return Ok(response);
        }
        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> Put([FromBody] DepartmentDTO departmentDTO)
        {
            var response = await _mediator.Send(new UpdateDepartmentCommand { DepartmentDTO = departmentDTO });
            return Ok(response);
        }
        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteDepartmentCommand { Id = id });
            return Ok(response);
        }
    }
}