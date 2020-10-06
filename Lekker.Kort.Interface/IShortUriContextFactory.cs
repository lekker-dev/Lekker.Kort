using Microsoft.EntityFrameworkCore;

namespace Lekker.Kort.Interface
{
    public interface IShortUriContextFactory
    {
        DbContext CreateDbContext();
    }
}