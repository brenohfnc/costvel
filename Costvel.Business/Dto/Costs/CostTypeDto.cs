using Costvel.Database.Entities;

namespace Costvel.Business.Dto.Costs;

public class CostTypeDto
{
    private CostTypeDto()
    {
    }

    public required int Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public required int Order { get; init; }

    public static CostTypeDto From(CostType costType)
        => new()
        {
            Id = costType.Id,
            Name = costType.Name,
            Description = costType.Description,
            Order = costType.Order
        };
}