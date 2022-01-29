using System.Reflection.Metadata;
namespace PayspotAPI.Infrastructure.Entity;
public class Notification
{
    public int Id { get; set; }
    public string AgentId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime Expiry { get; set; }
    public int ReadStatus { get; set; } = 0;
}