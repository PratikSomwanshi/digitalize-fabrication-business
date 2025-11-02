using DigitalizeFabricationBussiness.Models;
using System.Collections.Generic;

namespace DigitalizeFabricationBussiness.DTOs
{
    public class UserInputDTO
    {
        public string UserPhone { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserFullName { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public AddressInput? Address { get; set; }
    }

    public class UserOutputDTO
    {
        public Guid UserId { get; set; }
        public string UserPhone { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserFullName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public List<string> Roles { get; set; } = new();
        public Address? Address { get; set; }
    }

    public class LoginInputDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    
    public class LoginOutputDTO
    {
        public string UserName { get; set; } = string.Empty;
        
        public string UserEmail { get; set; } = string.Empty;
        public string Token { get; set; } =  string.Empty;
        
    }

 
    public class AddressInput
    {
        
        public string? Town { get; set; }
        
        public string? District { get; set; }
        
        public string County { get; set; } = string.Empty;
        
        public string PinCode { get; set; } = string.Empty;
    }
}