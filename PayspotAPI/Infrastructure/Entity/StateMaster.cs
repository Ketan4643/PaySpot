namespace PayspotAPI.Infrastructure.Entity
{
    public class StateMaster
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public int GstStateCode { get; set; }
    }
}