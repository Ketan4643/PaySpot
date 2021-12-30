namespace PayspotAPI.Infrastructure.Data;
public class Seed
{
    public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        if(await userManager.Users.AnyAsync()) return;

        var roles = new List<AppRole> {
            new AppRole { Name = Roles.SuperAdmin.ToString() },
            new AppRole { Name = Roles.Admin.ToString() },
            new AppRole { Name = Roles.Operations.ToString() },
            new AppRole { Name = Roles.Sales.ToString() },
            new AppRole { Name = Roles.Agent.ToString() },
            new AppRole { Name = Roles.Distributor.ToString() },
            new AppRole { Name = Roles.SuperDistributor.ToString() }
        };

        foreach(var role in roles)
        {
            await roleManager.CreateAsync(role);
        }
        
        var users = UserSeedData.GetUserData();


        foreach(var user in users)
        {
            user.UserName = user.UserName.ToLower();

            await userManager.CreateAsync(user, ConstantValues.DefaultPasword);
            await userManager.AddToRolesAsync(user, new[] { Roles.SuperAdmin.ToString() });
        }
    }
}