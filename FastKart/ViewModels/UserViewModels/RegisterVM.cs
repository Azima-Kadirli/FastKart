using System.ComponentModel.DataAnnotations;

namespace FastKart.ViewModels.UserViewModels
{
    public class RegisterVM
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [Required]
        [DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword {  get; set; }
    }
}
