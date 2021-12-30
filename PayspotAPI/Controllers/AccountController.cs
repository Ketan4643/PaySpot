namespace PayspotAPI.Controllers;
public class AccountController : BaseController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    // private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                             ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        // _mapper = mapper;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto dto)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == dto.Username.ToLower());

        if(user == null) return Unauthorized("Invalid Username");

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if(!result.Succeeded) return Unauthorized("Invalid Credentials");

        var roles = await _userManager.GetRolesAsync(user);

        return new UserDto {
            Username = user.UserName,
            Token = await _tokenService.CreateToken(user),
            Role = roles[0]
        };
    }

    private async Task<bool> UserExists(string username) => 
        await _userManager.Users.AnyAsync(x => x.UserName == username);
}