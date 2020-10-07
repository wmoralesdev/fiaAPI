using Domain.Attendants;
using Domain.BaseIdentities;
using Domain.Inscriptions;
using Domain.Presentations;
using Domain.Speakers;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IFIADbContext
    {
        DbSet<BaseIdentity> BaseIdentities { get; set; }

        DbSet<Speaker> Speakers { get; set; }

        DbSet<Attendant> Attendants { get; set; }

        DbSet<Inscription> Inscriptions { get; set; }

        DbSet<Presentation> Presentations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
