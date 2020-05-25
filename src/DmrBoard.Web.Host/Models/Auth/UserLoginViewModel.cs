using System.ComponentModel.DataAnnotations;

namespace DmrBoard.Application.Authorization.Dto
{
    public class UserLoginViewModel
    {
        [Required]
        [EmailAddress()]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
