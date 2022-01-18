namespace PayspotAPI.DTO.Admin;
public class NewUserDto
{
    public string Username { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Name { get; set; }
    public string GuardianName { get; set; }
    public string Nominee { get; set; }
    public string RelationShip { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Phonenumber { get; set; }
    public string Role { get; set; }
    public string DistributorId { get; set; }
    public string SuperDistributorId { get; set; }
}
