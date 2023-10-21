namespace eCommerce.Communication.Response;

public class UserRegistrationErrorResponse
{
    public List<string>? Messages { get; set; }

    public UserRegistrationErrorResponse(string msg)
    {
        Messages = new List<string>() { msg };
    }

    public UserRegistrationErrorResponse(List<string> msgs)
    {
        Messages = msgs;
    }
}