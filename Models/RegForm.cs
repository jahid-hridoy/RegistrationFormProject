using System.ComponentModel.DataAnnotations;

namespace RegistrationFormProject.Models;

public class RegForm
{   
    [Required]
    [Key]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; set; }
}