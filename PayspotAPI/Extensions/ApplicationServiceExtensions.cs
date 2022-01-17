using System.Collections.Generic;
using System.Reflection;
namespace PayspotAPI.Extensions;
public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service, IConfiguration config)
    {
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
        service.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
        service.Configure<AppSettings>(config.GetSection("AppSettings"));
        service.Configure<JwtTokenSettings>(config.GetSection("JwtTokenSettings"));
        service.AddScoped<ITokenService, TokenService>();
        service.AddScoped<IAdminService, AdminService>();
        service.AddScoped<IUnitOfWork, UnitIOfWork>();
        service.AddScoped<IAuthManager, AuthManager>();
        service.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        return service;
    }

    public static IServiceCollection AddSwaggerDoc(this IServiceCollection service)
    {
        service.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Payspot API",
                Version = "v1",
                Description = "Middleware for Payspot Userinterface",
                Contact = new OpenApiContact
                {
                    Name = "Prashant Kumar Snehi"
                }
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement() 
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference 
                        {
                            Type = ReferenceType.SecurityScheme,                                
                            Id = "Bearer"
                        },
                        Scheme = "0auth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });
        return service;
    }

}