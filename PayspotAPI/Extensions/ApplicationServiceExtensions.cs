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
        service.AddDbContext<DataContext>(options => {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        
        return service;
    }

}