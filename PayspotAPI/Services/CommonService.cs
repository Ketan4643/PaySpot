namespace PayspotAPI.Services;
public class CommonService : ICommonService
{
    public string GetRandomString(int length)
    {
        Random random = new Random();
        string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}