namespace LisaApi.Models;

public class Lease{
    public int LeaseId { get; set; }
    public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public LeasePaymentStatus PaymentStatus { get; set; }
    public byte[]? AgreementFormFileData { get; set; }

}


public enum LeasePaymentStatus{
    Pending,
    Completed,
    Failed
}