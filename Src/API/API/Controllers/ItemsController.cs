﻿using Application.DTOs.EntitiesDTOs.ItemDTOs;
using Application.Features.Items.Requests.Command;
using Application.Features.Items.Requests.Query;
using Application.Features.UnitOfMeasurement.Requests.Command;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllItems")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllItemsRequest());
            return Ok(response);
        }
        [HttpGet("GetItem/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetItemDetailsRequest { Id = id });
            return Ok(response);
        }
        [HttpPost("AddItems")]
        public async Task<IActionResult> Post([FromBody] ItemDTO itemDTO)
        {
            var response = await _mediator.Send(new CreateItemCommand { ItemDTO = itemDTO });
            return Ok(response);
        }

        [HttpPut("UpdateItem")]
        public async Task<IActionResult> Put([FromBody] ItemDTO itemDTO)
        {
            var response = await _mediator.Send(new UpdateItemCommand { ItemDTO = itemDTO });
            return Ok(response);
        }

        [HttpDelete("DeleteItem/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteItemCommand { Id = id });
            return Ok(response);
        }

    }
}
