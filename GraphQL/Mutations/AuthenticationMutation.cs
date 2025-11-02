using DigitalizeFabricationBussiness.DTOs;
using DigitalizeFabricationBussiness.Services.Interface;

namespace DigitalizedFabricationBusiness.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class AuthenticationMutation
{
    public async Task<UserOutputDTO> Register([Service] IUserService userService, UserInputDTO registerInput)
    {
        return await userService.Register(registerInput);
    }

    public async Task<LoginOutputDTO> Login([Service] IUserService userService, LoginInputDTO loginInput)
    {
        return await userService.Login(loginInput);
    }
}