namespace eCommerce.Infrastructure.Repositories;

public interface IUnitOfWork 
{
    Task Commit();
}