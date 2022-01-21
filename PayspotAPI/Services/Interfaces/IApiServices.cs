namespace PayspotAPI.Services.Interfaces;
public interface IApiServices
{
    Task<HttpResponseMessage> GetAsync(string baseUrl, string url);
    Task<HttpResponseMessage> GetAsync(string baseUrl, string url, HttpClient client);
    Task<HttpResponseMessage> PutAsync(string baseUrl, string url, StringContent stringContent);
    Task<HttpResponseMessage> PostAsync(string baseUrl, string url, string jsonString);
    Task<HttpResponseMessage> PostAsync(string baseUrl, string url, StringContent stringContent);
    Task<HttpResponseMessage> PostAsync(string baseUrl, string url, StringContent stringContent, HttpClient client);
    Task<HttpResponseMessage> PostAsync(string baseUrl, string url, FormUrlEncodedContent content, HttpClient client);
    Task<HttpResponseMessage> DeleteAsync(string baseUrl, string url);
}