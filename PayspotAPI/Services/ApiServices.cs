using System.Net;

namespace PayspotAPI.Services;
public class ApiServices : IApiServices
{
    private readonly IAppSettings _appSettings;
    public ApiServices(IAppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public async Task<HttpResponseMessage> GetAsync(string baseUrl, string url)
    {
        using (var client = new HttpClient())
        {
            //Passing service base url  
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            //make sure to use TLS 1.2 first before trying other version
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //set Accept headers
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml,application/json");
            //set User agent
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; EN; rv:11.0) like Gecko");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
            return await client.GetAsync(url);
        }
    }

    public async Task<HttpResponseMessage> GetAsync(string baseUrl, string url, HttpClient client)
    {
        //Passing service base url  
        client.BaseAddress = new Uri(baseUrl);
        //make sure to use TLS 1.2 first before trying other version
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        return await client.GetAsync(baseUrl + url);
    }

    public async Task<HttpResponseMessage> PutAsync(string baseUrl, string url, StringContent stringContent)
    {
        using (var client = new HttpClient())
        {
            //make sure to use TLS 1.2 first before trying other version
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.BaseAddress = new Uri(baseUrl);
            //set Accept headers
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml,application/json");
            //set User agent
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; EN; rv:11.0) like Gecko");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
            return await client.PutAsync(url, stringContent);
        }
    }

    public async Task<HttpResponseMessage> PostAsync(string baseUrl, string url, string jsonString)
    {
        using (var client = new HttpClient())
        {
            //make sure to use TLS 1.2 first before trying other version
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.BaseAddress = new Uri(baseUrl);
            client.Timeout = new TimeSpan(0, _appSettings.ApiTimeoutMinutes, 0);

            //set User agent
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; EN; rv:11.0) like Gecko");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
            return await client.PostAsync(url, new StringContent(jsonString));
        }
    }

    public async Task<HttpResponseMessage> PostAsync(string baseUrl, string url, StringContent stringContent)
    {
        using (var client = new HttpClient())
        {
            //make sure to use TLS 1.2 first before trying other version
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.BaseAddress = new Uri(baseUrl);
            client.Timeout = new TimeSpan(0, _appSettings.ApiTimeoutMinutes, 0);
            //set Accept headers
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml,application/json");
            //set User agent
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; EN; rv:11.0) like Gecko");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
            return await client.PostAsync(url, stringContent);
        }
    }

    public async Task<HttpResponseMessage> PostAsync(string baseUrl, string url, StringContent stringContent, HttpClient client)
    {
        //make sure to use TLS 1.2 first before trying other version
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        client.BaseAddress = new Uri(baseUrl);
        client.Timeout = new TimeSpan(0, _appSettings.ApiTimeoutMinutes, 0); //Timeout.InfiniteTimeSpan;
                                                                             ////set Accept headers
        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml,application/json");
        //set User agent
        client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; EN; rv:11.0) like Gecko");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
        var response = await client.PostAsync(url, stringContent);
        return response;
    }

    public async Task<HttpResponseMessage> PostAsync(string baseUrl, string url, FormUrlEncodedContent content, HttpClient client)
    {
        //make sure to use TLS 1.2 first before trying other version
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        client.BaseAddress = new Uri(baseUrl);
        client.Timeout = new TimeSpan(0, _appSettings.ApiTimeoutMinutes, 0); //Timeout.InfiniteTimeSpan;

        var response = await client.PostAsync(url, content);
        return response;
    }

    public async Task<HttpResponseMessage> DeleteAsync(string baseUrl, string url)
    {
        using (var client = new HttpClient())
        {
            //make sure to use TLS 1.2 first before trying other version
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.BaseAddress = new Uri(baseUrl);
            //set Accept headers
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml,application/json");
            //set User agent
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; EN; rv:11.0) like Gecko");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
            return await client.DeleteAsync(url);
        }
    }
}