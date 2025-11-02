using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.Models;


public class Order: BaseEntity
{
    public string OrderId { get; set; } = string.Empty;
    
    public string OrderDescription { get; set; }
    
    public List<string> OrderImages {  get; set; }
    
    public List<string> OrderInternalNotes { get; set; }
    
    public User User { get; set; }
    
    public Product Product { get; set; }
    
    public OrderStatusEnum OrderStatus { get; set; }
}