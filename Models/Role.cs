using Microsoft.EntityFrameworkCore;

namespace DigitalizeFabricationBussiness.Models;

public class Role 
{
    public Guid RoleId { get; set; } 
    
    public string RoleName { get; set; } = string.Empty;


    public override string ToString()
    {
        return $"Role: {RoleName}";
    }
}