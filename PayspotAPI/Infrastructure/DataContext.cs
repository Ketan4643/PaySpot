using System.Collections.Immutable;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PayspotAPI.Infrastructure.Entity;
using PayspotAPI.Infrastructure.EntityConfiguration;

namespace PayspotAPI.Infrastructure;
public class DataContext : IdentityDbContext<AppUser, AppRole, int,
                           IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
                           IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    
    public DataContext(DbContextOptions option) : base(option)
    {
    }

    public DbSet<Lead> Leads { get; set; }
    public DbSet<StateMaster> StateMasters { get; set; }
    public DbSet<TransactionDb> TransactionDb { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
            
        builder.Entity<AppUser>()
            .HasMany(a => a.AddressDetails)
            .WithOne(u => u.AppUser)
            .HasForeignKey(ur => ur.AppUserId)
            .IsRequired();
        
        builder.ApplyConfiguration(new LeadConfiguration());
        builder.ApplyConfiguration(new StateMasterConfiguration());
        builder.Entity<Notification>().ToTable("Notifications")
            .HasKey(x => x.Id);
    }
}