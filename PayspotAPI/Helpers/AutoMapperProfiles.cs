namespace PayspotAPI.Helpers;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, UserDto>().ReverseMap();
        CreateMap<RegisterDto, Lead>().ReverseMap();
        CreateMap<StatesDto, StateMaster>().ReverseMap();
        CreateMap<QueryDto, Lead>().ReverseMap();
        CreateMap<NewUserDto, AppUser>().ReverseMap();
        CreateMap<AddressDetail, AddressDto>().ReverseMap();
    }
}