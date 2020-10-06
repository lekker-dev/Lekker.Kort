using Lekker.Kort.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace Lekker.Kort.Repository.Context
{
    public class KortContext : DbContext
    {
        private readonly string _connectionString;

        public KortContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public KortContext(DbContextOptions<KortContext> options) : base(options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbConstants.SchemaName);
        }
    }
}