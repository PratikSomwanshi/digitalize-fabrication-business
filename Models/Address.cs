using System.ComponentModel.DataAnnotations;

namespace DigitalizeFabricationBussiness.Models;

public class Address : BaseEntity
{
    [Key]
    public Guid AddressId { get; set; } = Guid.NewGuid();
    
    public string Town { get; set; } = string.Empty;
    
    public string District { get; set; } = string.Empty;
    
    [Required]
    public string County { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(10)]
    public string PinCode { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }
}