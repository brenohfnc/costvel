using Costvel.Business.Dto.Location;
using Costvel.Database;
using Costvel.Database.Entities;

namespace Costvel.Business;

public class LocationsManager(CostvelContext context)
{
    public async Task Create(string mapId, string city, string state, string country, string coordinates)
    {
        var existingPlace = context.Locations.FirstOrDefault(x => x.MapId == mapId);

        if (existingPlace != null)
        {
            return;
        }

        var place = new Location
        {
            MapId = mapId,
            City = city,
            State = state,
            Country = country,
            Coordinates = coordinates
        };

        context.Locations.Add(place);

        await context.SaveChangesAsync();
    }

    public LocationDetailDto? GetDetails(string mapId)
    {
        var location = context.Locations.FirstOrDefault(location => location.MapId == mapId);

        if (location == null)
        {
            return null;
        }

        var costs = context.Costs
            .Where(cost => cost.LocationId == location.Id)
            .ToList();

        var costsByContributor = costs.GroupBy(cost => cost.RequesterIp).ToList();

        decimal costsAverage = 0, costsMin = 0, costsMax = 0;
        var numberOfContributors = costsByContributor.Count;

        if (numberOfContributors > 0)
        {
            costsAverage = costsByContributor.Average(group => group.Sum(cost => cost.Value));
            costsMin = costsByContributor.Min(group => group.Sum(cost => cost.Value));
            costsMax = costsByContributor.Max(group => group.Sum(cost => cost.Value));
        }

        var costsPerType = costs
            .GroupBy(cost => cost.CostTypeId)
            .Select(group => new LocationDetailCostDto
            {
                Type = group.First().CostType.Name,
                Average = group.Average(cost => cost.Value),
                Min = group.Min(cost => cost.Value),
                Max = group.Max(cost => cost.Value)
            });

        // Get the top five contributions in this country and the average cost of the contributions.
        var countryCosts = context.Locations
            .Where(l => l.Country == location.Country && l.Id != location.Id)
            .GroupBy(l => l.City)
            .ToList()
            .OrderByDescending(cityGroup => cityGroup.Sum(l => l.Costs.Sum(c => c.Value)))
            .Take(4)
            .Select(cityGroup =>
            {
                var byContributor = cityGroup
                    .SelectMany(l => l.Costs)
                    .GroupBy(c => c.RequesterIp)
                    .ToList();

                if (byContributor.Count == 0)
                {
                    return null;
                }

                var averageCost = byContributor.Average(group => group.Sum(c => c.Value));

                return new LocationDetailCountryCostDto
                {
                    City = cityGroup.Key,
                    Average = averageCost
                };
            })
            .Where(countryCost => countryCost != null)
            .ToList();
        
        countryCosts.Insert(0, new LocationDetailCountryCostDto
        {
            City = location.City,
            Average = costsAverage
        });

        return new LocationDetailDto
        {
            MapId = location.MapId,
            City = location.City,
            State = location.State,
            Country = location.Country,
            CostsAverage = costsAverage,
            CostsMin = costsMin,
            CostsMax = costsMax,
            NumberOfContributors = numberOfContributors,
            Costs = costsPerType,
            CountryCosts = countryCosts
        };
    }
}