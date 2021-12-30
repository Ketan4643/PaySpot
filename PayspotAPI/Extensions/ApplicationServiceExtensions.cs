namespace PayspotAPI.Extensions;
public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service, IConfiguration config)
    {
        
        service.AddScoped<ITokenService, TokenService>();
        service.AddDbContext<DataContext>(options => {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        
        return service;
    }

}