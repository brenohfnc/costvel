namespace Costvel.Business.Dto;

public class SaveCostDto
{
    public int CityId { get; set; }

    public int CostTypeId { get; set; }

    public decimal Value { get; set; }

    public string? RequesterIp { get; set; }
}