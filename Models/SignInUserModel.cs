using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Models
{
    public class SignInUserModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email Adress")]
        [EmailAddress(ErrorMessage = "Please enter a valid email adress")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Remember this user")]
        public bool RememberMe { get; set; }
    }
}
