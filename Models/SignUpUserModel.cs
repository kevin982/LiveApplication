using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        [MinLength(4)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        [MinLength(4)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your age")]
        [Display(Name = "Age")]
        [Range(18, 100)]

        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email Adress")]
        [EmailAddress(ErrorMessage = "Please enter a valid email adress")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your birthday")]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date, ErrorMessage = "Choose a date")]
        public DateTime Birthday { get; set; } = new();


        [Required(ErrorMessage = "Please enter your Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;


    }
}
