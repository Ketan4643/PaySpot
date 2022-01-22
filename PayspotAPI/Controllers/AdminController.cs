using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;

namespace PayspotAPI.Controllers;
public class AdminController : BaseController
{
    private readonly IAdminService _adminService;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IMapper _mapper;
    public AdminController(IAdminService adminService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
    {
        _adminService = adminService;
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (!ModelState.IsValid) return BadRequest("Invalid Data");

        var result = await _adminService.RegisterCallbackRequest(registerDto);
        if (result.StatusCode == StatusCodes.Status202Accepted)
            return Accepted(System.Text.Json.JsonSerializer.Serialize(result));
        return BadRequest(System.Text.Json.JsonSerializer.Serialize(result));
    }

    [AllowAnonymous]
    [HttpGet("getstates")]
    [ResponseCache(CacheProfileName = "120SecondProfiler")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> GetStates() => Ok(await _adminService.GetStates());

    [Authorize]
    [HttpGet("getqueries")]
    [ResponseCache(CacheProfileName = "120SecondProfiler")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> GetQueries([FromQuery] RequestParams requestParams)
    {
        var queries = await _adminService.GetQueries(requestParams);
        if (queries.Count == 0 || queries == null) return NotFound("No record found");

        return Ok(queries);
    }

    [Authorize]
    [HttpPost("add-agent")]
    public async Task<IActionResult> AddAgent([FromBody] NewUserDto dto)
    {
        var user = await _userManager.Users.AnyAsync(x => x.Email == dto.Email || x.PhoneNumber == dto.Phonenumber);
        if (user) return BadRequest("Email or Phonenumber is already registered");

        var maxId = await _userManager.Users.OrderByDescending(x => x.CreatedOn).LastOrDefaultAsync();
        dto.Username = string.Concat("m", (maxId.Id + 1).ToString().PadLeft(5, '0'));

        var userDto = _mapper.Map<AppUser>(dto);
        var result = await _userManager.CreateAsync(userDto, ConstantValues.DefaultPasword);

        if (!result.Succeeded) return BadRequest("Error registring. Please try again");

        await _userManager.AddToRolesAsync(userDto, new[] { dto.Role });
        return Ok();
    }

    [Authorize]
    [HttpPost("update-address")]
    public async Task<IActionResult> UpdateAddress([FromBody] AddressDto dto)
    {
        dto.LoginUser = User.GetUsername();
        var result = await _adminService.UpdateAddressAsync(dto);
        if(result.StatusCode == StatusCodes.Status400BadRequest) return BadRequest("User not found");
        return Ok(result);
    }

    [Authorize]
    [HttpPost("update-kyc")]
    public async Task<IActionResult> UpdateKycDocuments([FromBody] KycDocumentDto dto)
    {
        var loginUser = User.GetUsername();
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == dto.Username);
        if (user == null) return BadRequest("User not found");

        user.KycDetails.Add(new KycDetails{
            KycType = dto.KycType,
            DocumentNumber = dto.DocumentNumber,

        });

        return Ok(await _userManager.UpdateAsync(user));
    }
}