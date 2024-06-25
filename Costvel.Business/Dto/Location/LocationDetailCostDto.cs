namespace Costvel.Business.Dto.Location;

public class LocationDetailCostDto
{
    public required string Type { get; init; }

    public decimal Average { get; init; }
    
    public decimal Min { get; init; }
    
    public decimal Max { get; init; }
}