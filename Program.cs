using System.Text;
using DigitalizedFabricationBusiness.GraphQL.AuthenticationQuery;
using DigitalizedFabricationBusiness.GraphQL.Mutations;
using DigitalizedFabricationBusiness.Middlewares;
using DigitalizeFabricationBussiness.ApplicationDBContext;
using DigitalizeFabricationBussiness.GraphQL.Types;
using DigitalizeFabricationBussiness.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using DigitalizeFabricationBussiness.Services.Interface;
using DigitalizeFabricationBussiness.Services;
using DigitalizeFabricationBussiness.Repositories.Interface;
using DigitalizeFabricationBussiness.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DigitalizeFabricationBusinessDBContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddTypeExtension<AuthenticationQuery>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<AuthenticationMutation>()
    .AddType<UserType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddErrorFilter<GraphQLErrorFilter>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

app.UseGlobalExceptionHandler();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL("/graphql");

app.Run();