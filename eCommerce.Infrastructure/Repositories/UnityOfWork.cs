using eCommerce.Infrastructure.DatabaseContext;

namespace eCommerce.Infrastructure.Repositories;

public class UnityOfWork : IDisposable, IUnitOfWork
{
    private readonly eCommerceDbContext _db;
    private bool _disposed;
    
    public UnityOfWork(eCommerceDbContext context)
    {
        _db = context;
    }
    
    public void Dispose()
    {
        Dispose(true);
    }

    public async Task Commit()
    {
        await _db.SaveChangesAsync();
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _db.Dispose();
        }

        _disposed = true;
    }
}