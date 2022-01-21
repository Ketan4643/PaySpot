using System.ComponentModel;
namespace PayspotAPI.Helpers;
public static class ConstantValues
{
    public static string DefaultPasword = "P@ssw0rd";
}

public enum Roles
{
    [DescriptionAttribute("Super Admin")]
    SuperAdmin,
    Admin,
    Operations,
    Sales,
    Agent,
    Distributor,
    SuperDistributor
}

public enum Gender
{
    Male,
    Female,
    Others
}

public enum AddressType
{
    WorkAddress,
    ResidenceAddress
}

public enum AddressStatus
{
    Owner,
    Leased,
    Rented
}

public enum Nominee
{
    Spouse,
    Son, 
    Daughter,
    Friend,
    Relative,
    Other
}

public enum ApiMode 
{
    L,  // Live
    D   // Development
}