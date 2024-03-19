using Application.DTOs.EntitiesDTOs.UnitOfMeasurementDTOs;
using Application.Features.UnitOfMeasurement.Requests.Command;
using Application.Features.UnitOfMeasurement.Requests.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UomsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UomsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUoms")]
        public async Task<IActionResult> Get()
        {
            var uoms = await _mediator.Send(new GetAllUOMsRequest());
            return Ok(uoms);
        }

        [HttpGet("GetUom/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var uom = await _mediator.Send(new GetUOMDetailsRequest { Id = id });
            return Ok(uom);
        }

        [HttpPost("AddUom")]
        public async Task<IActionResult> Post([FromBody] UOMDTO uOMDTO)
        {
            var response = await _mediator.Send(new CreateUOMCommand { UOMDTO = uOMDTO });
            return Ok(response);
        }
    }
}
