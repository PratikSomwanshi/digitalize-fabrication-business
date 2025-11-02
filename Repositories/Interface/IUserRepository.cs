
using DigitalizeFabricationBussiness.Models;

namespace DigitalizeFabricationBussiness.Repositories.Interface;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    
    Task<User?> GetUserByUsername(string username);
    
    Task<User?> GetUserByEmail(string username);
    
}