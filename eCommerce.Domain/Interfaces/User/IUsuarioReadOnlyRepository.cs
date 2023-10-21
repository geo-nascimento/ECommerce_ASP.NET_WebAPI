namespace eCommerce.Domain.Interfaces.User;

public interface IUsuarioReadOnlyRepository
{
    Task<bool> ExitUserWithEmail(string email);
    Task<Models.User> Login(string email, string password);
}