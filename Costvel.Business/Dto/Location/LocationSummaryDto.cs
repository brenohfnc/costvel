using Costvel.Database.Entities;

namespace Costvel.Business.Dto.Location;

public class LocationSummaryDto
{
    public required int CostsCount { get; init; }

    public required int ContributorsCount { get; init; }

    public required IEnumerable<LocationSummaryDetailDto> Locations { get; init; }

    public static LocationSummaryDto From(
        IReadOnlyList<Cost> costs,
        IReadOnlyList<Database.Entities.Location> locations)
    {
        var costsCount = costs.Count;
        var contributorsCount = costs.GroupBy(x => x.RequesterIp).Distinct().Count();

        return new LocationSummaryDto
        {
            CostsCount = costsCount,
            ContributorsCount = contributorsCount,
            Locations = locations.Select(LocationSummaryDetailDto.From)
        };
    }
}