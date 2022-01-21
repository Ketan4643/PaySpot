using PayspotAPI.Helpers.Interfaces;

namespace PayspotAPI.Helpers;
public class PayzoneSettings : IPayzoneSettings
{
    public string Mode { get; set; }

    public string BaseUrlUat { get; set; }

    public string UsernameUat { get; set; }

    public string PasswordUat { get; set; }

    public string BaseUrl { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }
}