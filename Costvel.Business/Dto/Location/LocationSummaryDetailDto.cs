namespace Costvel.Business.Dto.Location;

public class LocationSummaryDetailDto
{
    public required string MapId { get; init; }

    public required string City { get; init; }

    public required string Coordinates { get; init; }

    public static LocationSummaryDetailDto From(Database.Entities.Location location)
        => new()
        {
            MapId = location.MapId,
            Coordinates = location.Coordinates,
            City = location.City
        };
}