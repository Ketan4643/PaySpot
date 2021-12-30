namespace PayspotAPI.Infrastructure.Entity;
public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}