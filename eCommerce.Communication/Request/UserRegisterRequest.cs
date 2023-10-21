namespace eCommerce.Communication.Request;

public class UserRegisterRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
}