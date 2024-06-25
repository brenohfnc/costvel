using System.ComponentModel.DataAnnotations;

namespace Costvel.Business.Dto.Costs;

public class SubmitCostTypeDto
{
    [Required] 
    public int Id { get; set; }
    
    [Required]
    public decimal Value { get; set; }
}