using Microsoft.EntityFrameworkCore;

namespace Lekker.Kort.Interface
{
    public interface IShortUrlContextFactory
    {
        DbContext CreateDbContext();
    }
}