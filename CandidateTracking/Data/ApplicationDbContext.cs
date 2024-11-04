using CandidateTracking.Components.Pages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CandidateTracking.Models;

namespace CandidateTracking.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    public DbSet<Candidate> Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed sample data for the Candidates table
        modelBuilder.Entity<Candidate>().HasData(
            new Candidate { Id = 1, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com", PhoneNumber = "1234567890", ResidentialZipCode = "12345" },
            new Candidate { Id = 2, FirstName = "Jane", LastName = "Smith", EmailAddress = "jane.smith@example.com", PhoneNumber = "0987654321", ResidentialZipCode = "54321" }
        );
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public List<Candidate> GetDbSets()
    {
        return this.Set<Candidate>().ToList();
    }
}