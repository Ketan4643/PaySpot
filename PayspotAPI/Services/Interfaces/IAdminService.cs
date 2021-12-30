namespace PayspotAPI.Services.Interfaces;
public interface IAdminService
{
    Task<CommonResponseDto> RegisterCallbackRequest(RegisterDto dto);
}
