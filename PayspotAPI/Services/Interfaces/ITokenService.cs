namespace PayspotAPI.Services.Interaces;
public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}