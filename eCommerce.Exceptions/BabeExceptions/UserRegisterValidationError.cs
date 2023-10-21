namespace eCommerce.Exceptions.BabeExceptions;

public class UserRegisterValidationError : eCommerceException
{
    public List<string>? ErroMessages { get; set; }
    
    public UserRegisterValidationError(List<string> erroMessages) : base(String.Empty)
    {
        this.ErroMessages = erroMessages;
    }
}