namespace PayspotAPI.Helpers;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, UserDto>().ReverseMap();
        CreateMap<RegisterDto, Lead>().ReverseMap();
    }
}