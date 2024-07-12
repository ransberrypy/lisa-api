using System.ComponentModel.DataAnnotations;

namespace LisaApi.Models;

public class TenantLease
{   
    [Key]
    public int TenantLeaseId { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; } = null!;

    public int TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public decimal AmountPaid { get; set; }
    public Lease Lease { get; set; } = new Lease();
    public string LeaseDuration { get; set; } = null!;
    // Additional columns for rental information
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<Witness> Witnesses { get; set; } = new List<Witness>();
    public DateTime UpdatedAt { get; set; }

}