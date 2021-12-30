namespace PayspotAPI.Controllers;
public class AdminController: BaseController 
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if(!ModelState.IsValid) return BadRequest("Invalid Data");

        var result = await _adminService.RegisterCallbackRequest(registerDto);
        if(result.StatusCode == StatusCodes.Status202Accepted) 
            return Accepted(System.Text.Json.JsonSerializer.Serialize(result));
        return BadRequest(System.Text.Json.JsonSerializer.Serialize(result)); 
    }
}