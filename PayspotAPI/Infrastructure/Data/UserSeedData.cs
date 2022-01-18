namespace PayspotAPI.Infrastructure.Data;
public static class UserSeedData
{
    public static List<AppUser> GetUserData() => 
        new List<AppUser> {
            new AppUser {
                UserName = "SA00001",
                Gender = Gender.Male.ToString(),
                DateOfBirth = new DateTime(1977,09,06),
                Nominee = "Wife",
                RelationShip = Nominee.Spouse.ToString(),
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Email = "psnehi@gmail.com",
                PhoneNumber = "9999999999",
                AddressDetails = new List<AddressDetail> {
                    new AddressDetail {
                        AddressType = AddressType.WorkAddress.ToString(),
                        AddressStatus = AddressStatus.Owner.ToString(),
                        Address = "New Delhi", 
                        Pincode = "110085",
                        City = "New Delhi",
                        Latitude = 0,
                        Longitude = 0,
                        StateCode = "DL",
                        NoOfPerson = 4,
                        IsCurrentAddress = true
                    }
                },
                IsActive = true
            }
        };
}