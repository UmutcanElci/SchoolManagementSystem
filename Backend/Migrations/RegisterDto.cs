namespace Backend.Migrations;

public class RegisterDto
{
    public string StudentName { get; set; }
    public string StudentSurname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Age { get; set; }
    public int Grade { get; set; }
    public string Address { get; set; }
    public string FatherName { get; set; }
    public string MotherName { get; set; }
    public bool Gender { get; set; }
    public string Email { get; set; }
    public int IdentityId { get; set; }
    public string PhoneNumber { get; set; }
}