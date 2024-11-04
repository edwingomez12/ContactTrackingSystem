using CandidateTracking.Models;

namespace CandidateTracking.Service;

public interface ICandidateService
{
    List<Candidate> GetFilteredCandidates(string searchTerm, List<Candidate> candidates);
}