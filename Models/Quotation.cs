using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.Models;

public class Quotation : BaseEntity
{
    public string QuotationId { get; set; } = string.Empty;

        public Order? Order { get; set;}

    public List<string> QuotationDetails { get; set; } = new();

    public decimal TotalAmount { get; set; }

    public QuotationStatusEnum Status { get; set; }

    public List<string> QuotationFiles { get; set; } = new List<string>();
}
