using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using AutoMapper;
using DigitalizeFabricationBussiness.ApplicationDBContext;
using DigitalizeFabricationBussiness.DTOs;
using DigitalizeFabricationBussiness.Models;
using DigitalizeFabricationBussiness.Repositories.Interface;
using DigitalizeFabricationBussiness.Services.Interface;
using DigitalizeFabricationBussiness.Utilities.Enumes;
using DigitalizeFabricationBussiness.Utilities.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace DigitalizeFabricationBussiness.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _useRepository;
    private readonly IMapper _mapper;
    private readonly DigitalizeFabricationBusinessDBContext _context;
    private readonly IConfiguration _config;

    public UserService(
        IUserRepository useRepository,
        IMapper mapper,
        DigitalizeFabricationBusinessDBContext context,
        IConfiguration config
    )
    {
        _useRepository = useRepository;
        _mapper = mapper;
        _context = context;
        _config = config;
    }

    public async Task<UserOutputDTO> Register(UserInputDTO userDto)
    {
        User? existingUserByUsername = await _useRepository.GetUserByUsername(userDto.UserName);

        if (existingUserByUsername != null)
            throw new CustomException(HttpStatusCode.BadRequest,
                "User already exists with given username",
                code: ErrorCode.USER_ALREADY_EXISTS);

        User? existingUserByEmail = await _useRepository.GetUserByEmail(userDto.UserEmail);

        if (existingUserByEmail != null)
            throw new CustomException(HttpStatusCode.BadRequest,
                "User already exists with given email",
                code: ErrorCode.USER_ALREADY_EXISTS);

        User userTobeSaved = _mapper.Map<User>(userDto);

        Role? customerRole = await _context.Roles.FirstOrDefaultAsync(role => role.RoleName == nameof(RolesEnum.CUSTOMER));

        if (customerRole == null)
            throw new CustomException(HttpStatusCode.BadRequest,
                $"{nameof(RolesEnum.CUSTOMER)} role not found",
                ErrorCode.GENERAL_ERROR);

        userTobeSaved.Roles = new List<Role>([customerRole]);

        userTobeSaved.UserPassword = new PasswordHasher<object>()
            .HashPassword(userDto, userTobeSaved.UserPassword);

        User savedUser = await _useRepository.CreateUser(userTobeSaved);
        
        return _mapper.Map<UserOutputDTO>(savedUser);
        
    }

    public async Task<UserOutputDTO> GetUserByUserName(string username)
    {
        return _mapper.Map<UserOutputDTO>(
            await _useRepository.GetUserByUsername(username)
            );
    }
    
    public async Task<UserOutputDTO> GetUserByEmail(string email)
    {

        return  _mapper.Map<UserOutputDTO>(await _useRepository.GetUserByEmail(email));
    
    }

    public async Task<LoginOutputDTO> Login(LoginInputDTO loginInputDto)
    {
        User? existingUser = await _useRepository.GetUserByUsername(loginInputDto.UserName);

        if (existingUser is null)
            throw new CustomException(
                HttpStatusCode.NotFound,
                "User not found",
                ErrorCode.USER_NOT_FOUND);
        
        PasswordVerificationResult hasher = new PasswordHasher<object>()
            .VerifyHashedPassword(existingUser, existingUser.UserPassword, loginInputDto.Password);

        if (hasher == PasswordVerificationResult.Failed)
            throw new CustomException(
                HttpStatusCode.BadRequest, "Wrong Password", ErrorCode.PASSWORD_WRONG);

        string token = GenerateJWTToken(existingUser);
        
        return new LoginOutputDTO
        {
            UserName = existingUser.UserName,
            UserEmail = existingUser.UserEmail,
            Token = token
        };
    }

    private string GenerateJWTToken(User user)
    {
        SymmetricSecurityKey _key = new(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
        );
        
        SigningCredentials creds = new(
            _key,
            SecurityAlgorithms.HmacSha256
        );
        
        List<Claim> claims = new List<Claim>()
        {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.UserEmail),
        };
        
        user.Roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role.RoleName)));

        JwtSecurityToken token = new(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims.ToArray(),
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}