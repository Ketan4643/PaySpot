namespace PayspotAPI.Helpers;
public class JwtTokenSettings : IJwtTokenSettings
{
    public string TokenKey { get; set; }

    public string ValidIssuer { get; set; }

    public int LifeSpan { get; set; }

    public string Audiance { get; set; }
}