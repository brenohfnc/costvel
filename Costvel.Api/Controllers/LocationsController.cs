using Costvel.Business;
using Costvel.Business.Dto.Location;
using Costvel.Database;
using Microsoft.AspNetCore.Mvc;

namespace Costvel.Api.Controllers;

[ApiController]
[Route("locations")]
public class LocationsController : ControllerBase
{
    [HttpGet("summary")]
    public IActionResult Summary([FromServices] CostvelContext context)
    {
        var places = context.Locations.Where(x => x.Costs.Count != 0).ToList();
        var costs = context.Costs.ToList();

        var model = LocationSummaryDto.From(costs, places);

        return Ok(model);
    }
    
    [HttpGet("{mapId}")]
    public IActionResult GetDetails(
        [FromRoute] string mapId,
        [FromServices] LocationsManager locationsManager)
    {
        var details = locationsManager.GetDetails(mapId);
        
        if (details == null)
        {
            return NotFound();
        }

        return Ok(details);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] LocationCreateDto dto,
        [FromServices] LocationsManager locationsManager)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await locationsManager.Create(dto.MapId, dto.City, dto.State, dto.Country, dto.Coordinates);

        return NoContent();
    }
}