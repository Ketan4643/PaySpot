using Microsoft.AspNetCore.Authorization;

namespace PayspotAPI.Controllers;

[Authorize]
public class PayzoneController : BaseController
{
    private readonly IAppSettings _appSettings;
    private readonly IPayzoneServices _payzoneServices;
    public PayzoneController(IPayzoneServices payzoneServices, IAppSettings appSettings)
    {
        _appSettings = appSettings;
        _payzoneServices = payzoneServices;   
    }

    [HttpGet]
    [Route("gettoken")]
    public async Task<IActionResult> Login() => Ok(await _payzoneServices.PayzoneLoginServiceAsync());
}