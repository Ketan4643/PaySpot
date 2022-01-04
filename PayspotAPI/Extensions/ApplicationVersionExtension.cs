namespace PayspotAPI.Extensions;
public static class ApplicationVersionExtension
{
    public static IServiceCollection ConfigureVersion(this IServiceCollection service)
    {
        service.AddApiVersioning(opt =>
        {
            opt.ReportApiVersions = true;
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.DefaultApiVersion = new ApiVersion(1, 0);
        });
        return service;
    }
}