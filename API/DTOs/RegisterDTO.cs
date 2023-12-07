// Purpose: DTO for registering a user.

using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        
        [Required]
        public String DisplayName { get; set; }
        
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", 
            ErrorMessage = "Password must be complex")]
        public String Password { get; set; }

        public String Username { get; set; }
    }
}