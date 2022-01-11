using Microsoft.AspNetCore.Authorization;

namespace PayspotAPI.Controllers;
public class AdminController: BaseController 
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [AllowAnonymous]
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
    public async Task<ActionResult<List<QueryDto>>> GetQueries()
    {
        var queries = await _adminService.GetQueries();
        if(queries.Count == 0 || queries == null) return NotFound("No record found");

        return Ok(queries);
    }
}