using Microsoft.AspNetCore.Mvc;
using PixelHotel.Core.Events.Abstractions;
using PixelHotelRooms.Domain.Commands;
using System.Threading.Tasks;

namespace PixelHotelRooms.Api.Controllers;

[ApiController]
[Route("api/rooms")]
public sealed class RoomsController(IMediatorHandler _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryCreateCommand command)
    {
        var result = await _mediator.SendCommand(command);
        return Ok(result);
    }
}
