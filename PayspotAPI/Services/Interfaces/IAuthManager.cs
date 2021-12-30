namespace PayspotAPI.Services.Interfaces;
public interface IAuthManager
{
    Task<bool> ValidateUser(LoginDto dto);
    Task<string> CreateToken();
}
