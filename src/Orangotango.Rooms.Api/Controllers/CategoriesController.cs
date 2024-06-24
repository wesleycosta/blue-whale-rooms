using Microsoft.AspNetCore.Mvc;
using Orangotango.Api;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Rooms.Api.InputModels;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Domain.Categories.Commands;
using System;
using System.Threading.Tasks;

namespace Orangotango.Rooms.Api.Controllers;

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

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new CategoryRemoveCommand(id);
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

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] string? searchValue)
    {
        var result = await _categoryService.Search(searchValue);
        return Ok(result);
    }
}
