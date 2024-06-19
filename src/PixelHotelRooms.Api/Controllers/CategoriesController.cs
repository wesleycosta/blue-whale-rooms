using Microsoft.AspNetCore.Mvc;
using PixelHotel.Api;
using PixelHotel.Core.Bus.Abstractions;
using PixelHotelRooms.Api.InputModel;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;
using System;
using System.Threading.Tasks;

namespace PixelHotelRooms.Api.Controllers;

[Route("api/categories")]
public sealed class CategoriesController(IMediatorHandler _mediator,
    ICategoryService _categoryService) : MainController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryCreateUpdateInputModel inputModel)
    {
        var command = new CategoryCreateCommand(inputModel.Name);
        var result = await _mediator.SendCommand(command);

        return Created("~/api/categories", result);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CategoryCreateUpdateInputModel inputModel)
    {
        var command = new CategoryUpdateCommand(id, inputModel.Name);
        var result = await _mediator.SendCommand(command);

        return Ok(result);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _categoryService.GetById(id);
        return Ok(result);
    }
}
