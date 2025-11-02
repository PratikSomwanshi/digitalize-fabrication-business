using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.Models;

public class Payment : BaseEntity
{
    public string PaymentId { get; set; } = string.Empty;
    
    public string OrderId { get; set; } = string.Empty;
    
    public Order Order { get; set; }
    
    public decimal Amount { get; set; }
    
    public PaymentMethodEnum PaymentMethod { get; set; }
    
    public DateTime PaymentDate { get; set; }
    
    public PaymentStatusEnum PaymentStatus { get; set; }
    
    public string TransactionReference { get; set; } = string.Empty;
}
