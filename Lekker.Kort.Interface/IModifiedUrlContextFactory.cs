using Microsoft.EntityFrameworkCore;

namespace Lekker.Kort.Interface
{
    public interface IModifiedUrlContextFactory
    {
        DbContext CreateDbContext();
    }
}