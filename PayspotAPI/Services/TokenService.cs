using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace PayspotAPI.Services;
public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;
    private readonly UserManager<AppUser> _userManager;
    private readonly IJwtTokenSettings _jwtTokenSettings;

    public TokenService(IConfiguration config, UserManager<AppUser> userManager, IJwtTokenSettings jwtTokenSettings)
    {
        _userManager = userManager;
        _jwtTokenSettings = jwtTokenSettings;
        // _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenSettings.TokenKey));
    }
    public async Task<string> CreateToken(AppUser user)
    {
        // var jwtSettings = config
        var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
        };

        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(_jwtTokenSettings.LifeSpan),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}