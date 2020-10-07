using Domain.Attendants;
using Domain.BaseIdentities;
using Domain.Inscriptions;
using Domain.Presentations;
using Domain.Speakers;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class FIADbContext : DbContext, IFIADbContext
    {
        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Attendant> Attendants { get; set; }

        public DbSet<Presentation> Presentations { get; set; }

        public DbSet<Inscription> Inscriptions { get; set; }

        public DbSet<BaseIdentity> BaseIdentities { get; set; }

        public FIADbContext(DbContextOptions<FIADbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FIADbContext).Assembly);
        }
    }
}
