namespace Costvel.Database.Entities;

public class Location : BaseEntity
{
    public string MapId { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string Coordinates { get; set; }

    public virtual ICollection<Cost> Costs { get; set; }
}