namespace PayspotAPI.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations.Schema;
public class AddressDetail
{
    public int Id { get; set; }
    public AppUser AppUser { get; set; }
    public int AppUserId { get; set; }
    public string AddressType { get; set; }
    public string AddressStatus { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Pincode { get; set; }
    public string StateCode { get; set; }
    public int NoOfPerson { get; set; } = 1;
    public bool IsCurrentAddress { get; set; }
}