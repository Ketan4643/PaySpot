namespace PayspotAPI.Helpers.Interfaces;
public interface IAppSettings
{
    string TokenValidation { get; }
    int ApiTimeoutMinutes { get; }
    double TdsPercentage { get; }
}