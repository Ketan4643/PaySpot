namespace PayspotAPI.Services;
public class PayzoneServices : IPayzoneServices
{
    private readonly IPayzoneSettings _payzoneSettings;
    private readonly IAppSettings _appSettings;
    private readonly IApiServices _apiServices;
    private readonly string _baseUrl;
    private readonly string _username;
    private readonly string _password;

    public PayzoneServices(IApiServices apiServices, IPayzoneSettings payzoneSettings, IAppSettings appSettings)
    {
        _payzoneSettings = payzoneSettings;
        _appSettings = appSettings;
        _apiServices = apiServices;
        _baseUrl = _payzoneSettings.Mode == ApiMode.L.ToString() ?
                   _payzoneSettings.BaseUrl : _payzoneSettings.BaseUrlUat;
        _username = _payzoneSettings.Mode == ApiMode.L.ToString() ?
                   _payzoneSettings.Username : _payzoneSettings.UsernameUat;
        _password = _payzoneSettings.Mode == ApiMode.L.ToString() ?
                   _payzoneSettings.Password : _payzoneSettings.Password;
    }
    public async Task<string> PayzoneLoginServiceAsync()
    {
        string relativeUrl = "login";
        var creds = new LoginDto { Username = _username, Password = _password };
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var jsonString = JsonSerializer.Serialize(creds, options);
        
        var client = new HttpClient();
        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        client.DefaultRequestHeaders.TryAddWithoutValidation("accessToken", "USER_TOKEN_HERE");

        var stringContent = new StringContent(jsonString);

        var response = await _apiServices.PostAsync(_baseUrl, relativeUrl, stringContent, client);
        var responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    }
}