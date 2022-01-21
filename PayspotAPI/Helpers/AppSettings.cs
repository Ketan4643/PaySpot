namespace PayspotAPI.Helpers;
public class AppSettings : IAppSettings
{
    public string TokenValidation { get; set; }

    public int ApiTimeoutMinutes { get; set; }
    public double TdsPercentage { get; set; }
}
