using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PixelHotel.Api;
using PixelHotel.Core.Events.Abstractions;
using PixelHotel.Events.Rooms;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;
using System;
using System.Threading.Tasks;

namespace PixelHotelRooms.Api.Controllers;

[Route("api/categories")]
public sealed class CategoriesController(IMediatorHandler _mediator,
    ICategoryService _categoryService,
    IBus bus) : MainController
{

    [HttpPost("teste")]
    public async Task<IActionResult> Teste()
    {
        await bus.Publish(new RoomCreatedOrUpdatedEvent(Guid.NewGuid(), "teste", 123));
        await bus.Publish(new RoomRemovedEvent());

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryCreateCommand command)
    {
        var result = await _mediator.SendCommand(command);
        return Created("~/api/categories", result);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _categoryService.GetById(id);
        return Ok(result);
    }
}
