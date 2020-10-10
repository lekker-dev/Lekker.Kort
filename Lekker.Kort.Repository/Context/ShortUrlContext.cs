using Lekker.Kort.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Repository.Context
{
    public class ShortUrlContext : DbContext
    {
        private readonly string _connectionString;

        public ShortUrlContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ShortUrlContext(DbContextOptions<ShortUrlContext> options) : base(options)
        {
        }

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

        public void Migrate()
        {
            if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();
            }
        }

        internal async Task<ShortenedUrl> AddShortUrlAsync(string id, string url, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var shortenedUrl = new ShortenedUrl(id, url);

            await ShortenedUrls.AddAsync(shortenedUrl, cancellationToken).ConfigureAwait(false);
            await SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return shortenedUrl;
        }

        internal async Task<ShortenedUrl> GetOriginalUrl(string key, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await ShortenedUrls.FirstAsync(s => s.Key == key, cancellationToken).ConfigureAwait(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_connectionString, options =>
                {
                    options.MigrationsHistoryTable(DbConstants.MigrationsTableName, DbConstants.SchemaName);
                });
            }
        }

        internal async Task<int> GetLastIndex(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await ShortenedUrls
                                .CountAsync()
                                .ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbConstants.SchemaName);
        }
    }
}