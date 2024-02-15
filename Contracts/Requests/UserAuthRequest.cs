using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class UserAuthRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public RoleType Role { get; set; } = RoleType.User;
    }


}
