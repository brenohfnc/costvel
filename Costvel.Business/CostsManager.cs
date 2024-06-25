using Costvel.Business.Dto.Costs;
using Costvel.Database;
using Costvel.Database.Entities;

namespace Costvel.Business;

public class CostsManager(CostvelContext context)
{
    public async Task Save(string mapId, IEnumerable<SubmitCostTypeDto> costTypes)
    {
        var location = context.Locations.FirstOrDefault(x => x.MapId == mapId);
        
        if (location == null)
        {
            throw new ArgumentException("City not found");
        }
        
        var requesterIp = Guid.NewGuid().ToString();
        
        foreach (var costType in costTypes)
        {
            var cost = new Cost
            {
                Value = costType.Value,
                LocationId = location.Id,
                CostTypeId = costType.Id,
                RequesterIp = requesterIp
            };

            await context.Costs.AddAsync(cost);
        }
        
        await context.SaveChangesAsync();
    }
}