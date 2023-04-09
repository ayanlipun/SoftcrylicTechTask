using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SoftcrylicTech.Library.DataContext;
using SoftcrylicTech.Library.DataFactories.Interfaces;
using System;

namespace SoftcrylicTech.Library.DataFactories
{
    public class DbFactory<TContext> : IContextFactory<TContext> where TContext : DbContext
    {
        IConfiguration _configuration;
        private ILogger<TContext> _logger;
        public DbFactory(IConfiguration configuration, ILogger<TContext> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public TechConfContext CreateTechConfContext()
        {
            TechConfContext techConfContext = null;

            try
            {
                string connectionString = FetchApplicationConnectionString();

                var contextBuilder = new DbContextOptionsBuilder<TechConfContext>();
                contextBuilder.UseSqlServer(connectionString);
                techConfContext = new TechConfContext(contextBuilder.Options, _configuration);
            }
            catch (Exception)
            {

                throw;
            }

            return techConfContext;
        }

        private string FetchApplicationConnectionString()
        {
            string connectionString = string.Empty;
            try
            {
                connectionString = _configuration["ConnectionString:TechConference"].ToString();
            }
            catch (Exception)
            {

                throw;
            }

            return connectionString;
        }
    }
}
