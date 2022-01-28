namespace PayspotAPI.Models;
public class TopupModel
{
    public string AgentId { get; set; }
    public string TopupMode { get; set; }
    public string TopupType { get; set; }
    public decimal TopupAmount { get; set; }
    public string Remarks { get; set; }
    public string UpdatedBy { get; set; }
    
    
}