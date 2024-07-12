using LisaApi.Models;
namespace LisaApi.Services.Dto;

// public class PropertyDto
// {
//     public string Name { get; set; } = null!;
//     public int Price { get; set; }
//     public string? MeterNumber { get; set; }
//     public string? MeterImg { get; set; }
//     public string? Address { get; set; }
//     public PropertyType Type { get; set; }
//     public RentalStatusEnum RentalStatus { get; set; }
// }

public class PropertyDto
{
    public string Name { get; set;} = null!;
    public int Price { get; set; }
    public string? MeterNumber { get; set; }
    public IFormFile? MeterImg { get; set; }
    public string? Address { get; set; }
    public PropertyType Type { get; set; }
    public RentalStatusEnum RentalStatus { get; set; }
}
