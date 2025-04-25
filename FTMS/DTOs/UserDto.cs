namespace FTMS.DTOs;

public class UserDto
{
    public string Id { get; set; }=string.Empty;
    public string FirstName { get; set; } 
    public string LastName { get; set; }  
    public string Email { get; set; }
    public string? ProfilePicBase64 { get; set; }
}
