using Costvel.Database.Entities;

namespace Costvel.Business.Extensions;

public static class CityExtensions
{
    public static string GetFullName(this Location location)
        => $"{location.City} - {location.State}";
}