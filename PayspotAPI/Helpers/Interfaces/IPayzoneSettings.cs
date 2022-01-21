namespace PayspotAPI.Helpers.Interfaces;
public interface IPayzoneSettings
{
    string Mode { get; }    
    string BaseUrlUat { get; }    
    string UsernameUat { get; }    
    string PasswordUat { get; }    
    string BaseUrl { get; }    
    string Username { get; }    
    string Password { get; }    
}