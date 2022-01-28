namespace PayspotAPI.Infrastructure.Entity;
public class TransactionDb
{
    public int Id { get; set; }
    public string Mode { get; set; }    // Debit/ Credit
    public string AgentId { get; set; }
    public DateTime TransactionDateTime { get; set; }
    public string TransactionId { get; set; }
    public string RequestId { get; set; }
    public string Utility { get; set; }
    public string UtilitySubType { get; set; }
    public string UtilityPartner { get; set; }
    public decimal BaseAmount { get; set; }
    public decimal CustomerFee { get; set; }
    public string TransactionType { get; set; }
    public int DistributorId { get; set; }
    public DateTime CompletedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public string Updatedby { get; set; }
    public string RequestJson { get; set; }
    public string ResponseJson { get; set; }
    public int TransactionStatusCode { get; set; }   // Initiated/ Success/ Failed/ RefundPending
    public string TransactionStatus { get; set; }   // Initiated/ Success/ Failed/ RefundPending
    public decimal OpeningBalance { get; set; }   // Initiated/ Success/ Failed/ RefundPending
    public decimal ClosingBalance { get; set; }   // Initiated/ Success/ Failed/ RefundPending
    public string Remarks { get; set; }   
}