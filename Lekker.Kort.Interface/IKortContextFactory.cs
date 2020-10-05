using Microsoft.EntityFrameworkCore;

namespace Lekker.Kort.Interface
{
    public interface IKortContextFactory
    {
        DbContext CreateDbContext();
    }
}