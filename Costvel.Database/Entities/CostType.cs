namespace Costvel.Database.Entities;

public class CostType : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int Order { get; set; }
    
    public virtual ICollection<Cost> Costs { get; set; }
}