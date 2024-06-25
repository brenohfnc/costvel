namespace Costvel.Database.Entities;

public class Cost : BaseEntity
{
    public decimal Value { get; set; }

    public string? RequesterIp { get; set; }

    public int LocationId { get; set; }

    public int CostTypeId { get; set; }

    public virtual Location Location { get; set; }

    public virtual CostType CostType { get; set; }
}