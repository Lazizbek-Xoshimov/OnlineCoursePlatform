namespace UserService.Domain.Entities;

public class User
{
    public short Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
