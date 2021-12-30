namespace PayspotAPI.Infrastructure.Entity;
public class KycDetails
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public string KycType { get; set; }
    public string DocumentNumber { get; set; }
    public string ImageUrl { get; set; }
    public string PublicId { get; set; }
    public bool IsMain { get; set; }
}