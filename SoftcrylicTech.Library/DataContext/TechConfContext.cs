using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoftcrylicTech.Library.DBEntities;
using SoftcrylicTech.Model;
using System;

namespace SoftcrylicTech.Library.DataContext
{
    public partial class TechConfContext : DbContext
    {
        public TechConfContext() { }
        public TechConfContext(DbContextOptions<TechConfContext> dbContext) : base(dbContext) { }
        public TechConfContext(DbContextOptions<TechConfContext> dbContext, IConfiguration configuration) : base(dbContext)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            //var timeout = configuration.GetSection("TimeOut").GetSection("TimeOutValue").Value;
            //this.Database.
        }

        public DbSet<tblEventEntity> EventEntities { get; set; }
        public DbSet<tblSpeakerEntity> SpeakerEntities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
