using FluentAssertions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using CandidateTracking.Models;

public class CandidateModelTests
{
    [Fact]
    public void Candidate_ShouldRequire_FirstName()
    {
        var candidate = new Candidate { LastName = "test", EmailAddress = "email@gmail.com" };
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(candidate);

        var isValid = Validator.TryValidateObject(candidate, context, validationResults, true);

        validationResults.Should().Contain(v => v.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void Candidate_ShouldRequire_LastName()
    {
        var candidate = new Candidate { FirstName = "test", EmailAddress = "test@gmail.com" };
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(candidate);

        var isValid = Validator.TryValidateObject(candidate, context, validationResults, true);

        validationResults.Should().Contain(v => v.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void Candidate_ShouldRequire_EmailAddress()
    {
        var candidate = new Candidate { FirstName = "test", LastName = "smith" };
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(candidate);

        var isValid = Validator.TryValidateObject(candidate, context, validationResults, true);

        validationResults.Should().Contain(v => v.MemberNames.Contains("EmailAddress"));
    }

    [Fact]
    public void Candidate_ShouldRequire_PhoneNumber()
    {
        var candidate = new Candidate
        {
            FirstName = "test", LastName = "smith" ,
            EmailAddress = "test@gmail.com"
            
        };
        
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(candidate);
        
        var isValid = Validator.TryValidateObject(candidate, context, validationResults, true);
        
        validationResults.Should().Contain(v => v.MemberNames.Contains("PhoneNumber"));
        
    }

    [Fact]
    public void Candidate_ShouldRequire_ResidentialZipCode()
    {
        var candidate = new Candidate
        {
            FirstName = "test", LastName = "smith",
            EmailAddress = "test@gmail.com", PhoneNumber = "9566477734"
        };
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(candidate);
        
        var isValid = Validator.TryValidateObject(candidate, context, validationResults, true);
        
        validationResults.Should().Contain(v => v.MemberNames.Contains("ResidentialZipCode"));
    }
}