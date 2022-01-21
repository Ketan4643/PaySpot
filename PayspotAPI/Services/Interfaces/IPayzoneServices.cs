namespace PayspotAPI.Services.Interfaces;
public interface IPayzoneServices
{
    Task<string> PayzoneLoginServiceAsync();
}