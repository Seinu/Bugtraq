using System.ComponentModel.DataAnnotations;

namespace bugtraq.API.Dtos
{
  public class DevForRegisterDto
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between then 8 and 16 characters.")]
    public string Password { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Department { get; set; }
  }
}