using Costvel.Business;
using Costvel.Business.Dto.Costs;
using Costvel.Database;
using Microsoft.AspNetCore.Mvc;

namespace Costvel.Api.Controllers;

[ApiController]
[Route("costs")]
public class CostsController : ControllerBase
{
    [HttpGet("types")]
    public IActionResult GetTypes([FromServices] CostvelContext context)
    {
        var costTypes = context.CostTypes.ToList();

        var model = costTypes.Select(CostTypeDto.From);

        return Ok(model);
    }

    [HttpPost("{mapId}")]
    public async Task<IActionResult> SubmitContribution(
        [FromRoute] string mapId,
        [FromBody] SubmitCostTypeDto[] costTypes,
        [FromServices] CostsManager costsManager)
    {
        await costsManager.Save(mapId, costTypes);

        return NoContent();
    }
}