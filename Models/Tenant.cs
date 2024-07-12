using System.ComponentModel.DataAnnotations;

namespace LisaApi.Models;

// Tenant Model
public class Tenant
{
    [Key]
    public int TenantId { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public string Phone { get; set; } = null!;
    public string? NextOfKin { get; set; }
    public string? EmergencyContact { get; set; }
    public string? AddressofNextofKin { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? Picture { get; set; }
    public string? GhanaCard { get; set; }
    public ICollection<TenantLease> TenantLease { get; set; } = new List<TenantLease>();
    public DateTime UpdatedAt { get; set; }
}
