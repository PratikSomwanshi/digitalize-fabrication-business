using DigitalizeFabricationBussiness.DTOs;
using DigitalizeFabricationBussiness.Models;

namespace DigitalizeFabricationBussiness.Services.Interface;

public interface IUserService
{
    Task<UserOutputDTO> Register(UserInputDTO userDto);
    
    Task<UserOutputDTO> GetUserByUserName(string username);
    
    Task<LoginOutputDTO> Login(LoginInputDTO loginInputDto);
}