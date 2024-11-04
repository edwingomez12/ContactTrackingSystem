using FluentAssertions;
using Xunit;
using CandidateTracking.Models;
using CandidateTracking.Service;

public class CandidateServiceTests
{
    private ICandidateService _service;
    private List<Candidate> _candidates;

    public CandidateServiceTests()
    {
        _service = new CandidateService();
        _candidates = new List<Candidate>
        {
            new Candidate
            {
                FirstName = "edwin", LastName = "gomez", EmailAddress = "test@gmail.com",
                PhoneNumber = "9671231234", ResidentialZipCode = "70000"
            },
            new Candidate
            {
                FirstName = "test", LastName = "smith", EmailAddress = "test2@gmail.com",
                PhoneNumber = "9671231235", ResidentialZipCode = "70001"
            },
            new Candidate
            {
                FirstName = "newtest", LastName = "smith", EmailAddress = "test3@gmail.com",
                PhoneNumber = "9671231236", ResidentialZipCode = "70001"
            }
        };
    }

    [Fact]
    public void GetFilteredCandidate_ByFirstName()
    {
        //arrange
        string searchTerm = "edwin";
        var expectedCandidates = new List<Candidate>
        {
            new Candidate()
            {
                FirstName = "edwin", LastName = "gomez", EmailAddress = "test@gmail.com",
                PhoneNumber = "9671231234", ResidentialZipCode = "70000"
            }
        };
        //act
        var response = _service.GetFilteredCandidates(searchTerm, _candidates);
        
        //assert
        response.Should().BeEquivalentTo(expectedCandidates);
    }
    
    [Fact]
    public void GetFilteredCandidate_ByLastName()
    {
        //arrange
        string searchTerm = "smith";
        var expectedCandidates = new List<Candidate>
        {
            new Candidate
            {
                FirstName = "test", LastName = "smith", EmailAddress = "test2@gmail.com",
                PhoneNumber = "9671231235", ResidentialZipCode = "70001"
            },
            new Candidate
            {
                FirstName = "newtest", LastName = "smith", EmailAddress = "test3@gmail.com",
                PhoneNumber = "9671231236", ResidentialZipCode = "70001"
            }
        };
        //act
        var response = _service.GetFilteredCandidates(searchTerm, _candidates);
        
        //assert
        response.Should().BeEquivalentTo(expectedCandidates);
    }
    
    [Fact]
    public void GetFilteredCandidate_ByZipCode()
    {
        //arrange
        string searchTerm = "70001";
        var expectedCandidates = new List<Candidate>
        {
            new Candidate
            {
                FirstName = "test", LastName = "smith", EmailAddress = "test2@gmail.com",
                PhoneNumber = "9671231235", ResidentialZipCode = "70001"
            },
            new Candidate
            {
                FirstName = "newtest", LastName = "smith", EmailAddress = "test3@gmail.com",
                PhoneNumber = "9671231236", ResidentialZipCode = "70001"
            }
        };
        //act
        var response = _service.GetFilteredCandidates(searchTerm, _candidates);
        
        //assert
        response.Should().BeEquivalentTo(expectedCandidates);
    }
    
    [Fact]
    public void GetFilteredCandidate_ReturnsNull_InvalidSearchTerm()
    {
        //arrange
        string searchTerm = "firstnametest";
        var expected = new List<Candidate>();

        //act
        var response = _service.GetFilteredCandidates(searchTerm, _candidates);
        
        //assert
        response.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void GetFilteredCandidate_EmptySearchTerm_ReturnsListOfCandidates()
    {
        //arrange
        string searchTerm = string.Empty;

        //act
        var response = _service.GetFilteredCandidates(searchTerm, _candidates);
        
        //assert
        response.Should().BeEquivalentTo(_candidates);
    }
}