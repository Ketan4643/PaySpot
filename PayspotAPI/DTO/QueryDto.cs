namespace PayspotAPI.DTO;
public class QueryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string State { get; set; }
    public string Query { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public DateTime UpdatedBy { get; set; }
    public bool PendingStatus { get; set; }   
}