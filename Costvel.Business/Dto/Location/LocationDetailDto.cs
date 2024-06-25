namespace Costvel.Business.Dto.Location;

public class LocationDetailDto
{
    public required string MapId { get; init; }

    public required string City { get; init; }

    public required string State { get; init; }
    
    public required string Country { get; init; }

    public required decimal CostsAverage { get; init; }

    public required decimal CostsMin { get; init; }

    public required decimal CostsMax { get; init; }

    public required int NumberOfContributors { get; init; }

    public required IEnumerable<LocationDetailCostDto> Costs { get; init; }

    public required IEnumerable<LocationDetailCountryCostDto> CountryCosts { get; init; }
}