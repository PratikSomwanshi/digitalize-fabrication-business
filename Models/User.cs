using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalizeFabricationBussiness.Models;

public class User: BaseEntity
{
    [Key]
    public Guid UserId { get; set; } =  Guid.NewGuid();
    
    public string UserPhone { get; set; } = string.Empty;
    
    public string UserEmail { get; set; } = string.Empty;
    
    public string UserName { get; set; } = string.Empty;
    
    public string UserFullName { get; set; } = string.Empty;
    
    public string UserPassword { get; set; } = string.Empty;
    
    public bool IsActive { get; set; } = false;
    
    public bool IsAdmin { get; set; } = false;
    
    public List<Role> Roles { get; set; } = new();
    
    public Address  Address { get; set; }
    
}

