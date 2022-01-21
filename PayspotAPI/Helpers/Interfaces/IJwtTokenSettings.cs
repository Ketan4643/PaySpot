namespace PayspotAPI.Helpers.Interfaces;
public interface IJwtTokenSettings
{
    string TokenKey { get; }
    string ValidIssuer { get; }
    int LifeSpan { get; }
    string Audiance { get; }
}