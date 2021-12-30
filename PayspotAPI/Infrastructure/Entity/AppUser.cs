namespace PayspotAPI.Infrastructure.Entity;
public class AppUser : IdentityUser<int>
{
    public DateTime DateOfBirth { get; set; }
    public string Name { get; set; }
    public string GuardianName { get; set; }
    public string Nominee { get; set; }
    public string RelationShip { get; set; }
    public string Gender { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; }
    public ICollection<AddressDetail> AddressDetails { get; set; }
    public ICollection<KycDetails> KycDetails { get; set; }
    public ICollection<AppUserRole> UserRoles { get; set; }
}