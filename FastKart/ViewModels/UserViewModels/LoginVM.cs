using System.ComponentModel.DataAnnotations;

namespace FastKart.ViewModels.UserViewModels
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
