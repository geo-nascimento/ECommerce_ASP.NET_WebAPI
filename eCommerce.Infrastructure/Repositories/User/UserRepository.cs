using eCommerce.Domain.Interfaces.User;
using eCommerce.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories.User;

public class UserRepository : IUserWriteOnlyRepository, IUsuarioReadOnlyRepository
{
    private readonly eCommerceDbContext _db;

    public UserRepository(eCommerceDbContext db)
    {
        _db = db;
    }
    
    public async Task AddUser(Domain.Models.User user)
    {
        await _db.AddAsync(user);
    }

    public async Task<bool> ExitUserWithEmail(string email)
    {
        return await _db.Users.AnyAsync(u => u.Email.Equals(email));
    }
    
    //TODO implementar a função de login depois 
    public Task<Domain.Models.User> Login(string email, string password)
    {
        throw new NotImplementedException();
    }
}