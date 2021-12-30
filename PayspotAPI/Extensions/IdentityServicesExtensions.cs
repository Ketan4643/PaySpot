using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace PayspotAPI.Extensions;
public static class IdentityServicesExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection service, IConfiguration config)
    {
        service.AddIdentityCore<AppUser>(opt => 
        {
            opt.Password.RequiredUniqueChars = 0;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireDigit = false;
            opt.User.RequireUniqueEmail = false;   
        }).AddRoles<AppRole>()
          .AddRoleManager<RoleManager<AppRole>>()
          .AddSignInManager<SignInManager<AppUser>>()
          .AddRoleValidator<RoleValidator<AppRole>>()
          .AddEntityFrameworkStores<DataContext>();

        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options => 
               {
                   options.TokenValidationParameters = new TokenValidationParameters {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                       ValidateAudience = false,
                       ValidateIssuer = false
                   };
               });
        return service;
    }
}