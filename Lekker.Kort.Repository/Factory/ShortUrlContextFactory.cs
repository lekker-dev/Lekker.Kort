using Lekker.Kort.Interface;
using Lekker.Kort.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Lekker.Kort.Repository.Factory
{
    public class ShortUrlContextFactory : IModifiedUrlContextFactory
    {
        private readonly string _connectionString;
        private bool _migrationsRan;

        public ShortUrlContextFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(DbConstants.AppSettings.ConnectionStrings.DB);
            if (_connectionString == null)
            {
                throw new ArgumentNullException($"Required connection string '{DbConstants.AppSettings.ConnectionStrings.DB}' not found!");
            }
        }

        public DbContext CreateDbContext()
        {
            var context = new ShortUrlContext(_connectionString);

            if (!_migrationsRan)
            {
                _migrationsRan = true;

                context.Migrate();
            }

            return context;
        }
    }
}