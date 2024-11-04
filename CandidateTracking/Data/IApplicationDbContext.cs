using CandidateTracking.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

public interface IApplicationDbContext
{
    DbSet<Candidate> Candidates { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    List<Candidate> GetDbSets();
}