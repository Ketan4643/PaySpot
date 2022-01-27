namespace PayspotAPI.Services.Interfaces;
public interface IAdminService
{
    Task<CommonResponseDto> RegisterCallbackRequest(RegisterDto dto);
    Task<ICollection<StatesDto>> GetStates();
    Task<ICollection<QueryDto>> GetQueries(RequestParams requestParams);
    Task<CommonResponseDto> UpdateAddressAsync(AddressDto dto);
    Task<CommonResponseDto> UpdateKycDocumentsAsync(KycDocumentDto dto);
    Task<CommonResponseDto> UpdateLeadStatus(Lead model);
}
