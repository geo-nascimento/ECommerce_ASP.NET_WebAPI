namespace eCommerce.Domain.Interfaces.User;

public interface IUserWriteOnlyRepository
{
    Task AddUser(Models.User user);
}