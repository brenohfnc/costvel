using System.ComponentModel.DataAnnotations;

namespace Costvel.Business.Dto.Location;

public class LocationCreateDto
{
    [Required]
    public string MapId { get; set; }
    
    [Required]
    public string City { get; set; }

    [Required]
    public string State { get; set; }
    
    [Required]
    public string Country { get; set; }
    
    [Required]
    public string Coordinates { get; set; }
}