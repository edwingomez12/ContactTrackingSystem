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
    
    [Theory]
    [InlineData("123-456-7890", true)]
    [InlineData("1234567890", true)]
    [InlineData("123-4567-890", true)]
    [InlineData("(123)-456-7890", true)]
    [InlineData("123-456-789a", false)]
    public void PhoneNumber_ShouldBeInCorrectFormat(string phoneNumber, bool isValid)
    {
        // Arrange
        var candidate = new Candidate
        {
            FirstName = "test",
            LastName = "test1",
            EmailAddress = "test@gmail.com",
            PhoneNumber = phoneNumber,
            ResidentialZipCode = "78577"
        };
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(candidate);

        // Act
        var result = Validator.TryValidateObject(candidate, validationContext, validationResults, true);

        // Assert
        result.Should().Be(isValid);
    }
    
    [Theory]
    [InlineData("78577", true)]
    [InlineData("785", false)]
    [InlineData("785-77", false)]
    [InlineData("abcd", false)]
    public void ZipCode_ShouldBeInCorrectFormat(string zipCode, bool isValid)
    {
        // Arrange
        var candidate = new Candidate
        {
            FirstName = "test",
            LastName = "test1",
            EmailAddress = "test@gmail.com",
            PhoneNumber = "123457897",
            ResidentialZipCode = zipCode
        };
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(candidate);

        // Act
        var result = Validator.TryValidateObject(candidate, validationContext, validationResults, true);

        // Assert
        result.Should().Be(isValid);
    }
}