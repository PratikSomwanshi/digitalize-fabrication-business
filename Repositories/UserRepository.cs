// using System.Data;
using System.Net;
using DigitalizeFabricationBussiness.ApplicationDBContext;
using DigitalizeFabricationBussiness.Models;
using DigitalizeFabricationBussiness.Repositories.Interface;
using DigitalizeFabricationBussiness.Utilities.Enumes;
using DigitalizeFabricationBussiness.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DigitalizeFabricationBussiness.Repositories;

public class UserRepository(
        DigitalizeFabricationBusinessDBContext _context
    ): IUserRepository
{
    public async Task<User> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        return await _context
            .Users
            .Include(user => user.Roles)
            .Include(user => user.Address)
            .FirstOrDefaultAsync(
                user 
                    => 
                    user.UserName.Equals(username));

    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context
            .Users
            .FirstOrDefaultAsync(
                user 
                    => 
                    user.UserEmail.Equals(email));
    }
}