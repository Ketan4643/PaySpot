namespace PayspotAPI.Services.Interfaces;
public interface IAdminService
{
    Task<CommonResponseDto> RegisterCallbackRequest(RegisterDto dto);
    Task<ICollection<StatesDto>> GetStates();
    Task<ICollection<QueryDto>> GetQueries();
}
