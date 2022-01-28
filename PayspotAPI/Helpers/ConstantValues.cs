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

public enum TransactionMode
{
    Debit,
    Credit
}

public enum TransactionStatus
{
    Success,
    Failure,
    Initiated,
    RefundPending,
    Refunded    
}

public enum TopupMode
{
    Cash,
    BankDeposit,
    Online,
    UPI,
    Wallet
}

public enum Utility 
{
    Topup,
    Electricity,
    Water
}

public enum UtilityPartner
{
    Payspot,
    ICICI_Bank
}
