using System.ComponentModel.DataAnnotations;

namespace CandidateTracking.Models;

public class Candidate
{
    [Key] 
    public int Id { get; set; }
    
    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email Address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Phone Number is required")]
    [Phone(ErrorMessage = "Invalid Phone Number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Residential Zip Code is required")]
    [StringLength(5, ErrorMessage = "Zip Code must be 5 digits", MinimumLength = 5)]
    [RegularExpression(@"^\d{5}$", ErrorMessage = "Zip Code must be 5 numeric digits")]
    public string ResidentialZipCode { get; set; }
}