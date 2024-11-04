using CandidateTracking.Models;
namespace CandidateTracking.Service;

public class CandidateService: ICandidateService
{
    public List<Candidate> GetFilteredCandidates(string searchTerm, List<Candidate> candidates)
    {
        if(string.IsNullOrEmpty(searchTerm))
            return candidates;
        else
        {    
            return candidates
                .Where(c =>
                    c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.EmailAddress.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.ResidentialZipCode.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}