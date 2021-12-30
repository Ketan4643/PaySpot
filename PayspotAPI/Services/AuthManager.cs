namespace PayspotAPI.Services;
public class AuthManager : IAuthManager
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _config;
    private AppUser _user;
    public AuthManager(UserManager<AppUser> userManager, IConfiguration config)
    {
        _userManager = userManager;
        _config = config;
    }
    public async Task<string> CreateToken() => await Task.FromResult("Success");

    public async Task<bool> ValidateUser(LoginDto dto)
    {
        _user = await _userManager.FindByNameAsync(dto.Username);
        // if(_user == null) return false;
        var validPassword = await _userManager.CheckPasswordAsync(_user, dto.Password);
        return (_user != null && validPassword);
    }
}
