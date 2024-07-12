namespace LisaApi.Models;


// Property Model
public class Property
{
    public int PropertyId { get; set; }
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public string? MeterNumber { get; set; }
    public string? MeterImg { get; set; }
    public string? Address { get; set; }
    public PropertyType Type { get; set; }
    public RentalStatusEnum RentalStatus { get; set; }
    public ICollection<TenantLease> TenantLease { get; set; } = new List<TenantLease>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }


}


public enum RentalStatusEnum
{
    Available,
    Occupied,
    UnderMaintenance
}


public enum PropertyType
{
    Apartment,
    House,
    Condo,
    Townhouse,
    Commercial
}