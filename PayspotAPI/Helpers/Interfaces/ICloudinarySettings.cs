namespace PayspotAPI.Helpers.Interfaces;
public interface ICloudinarySettings
{
    string CloudName { get; }
    string ApiKey { get; }
    string ApiSecret { get; }
}