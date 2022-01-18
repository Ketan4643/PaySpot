namespace PayspotAPI.DTO.Admin;
public class KycDocumentDto
{
    public string Username { get; set; }
    public string KycType { get; set; }
    public string DocumentNumber { get; set; }
    public IFormFile File { get ;set; }   
}
