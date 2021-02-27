using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Models
{
    public class ChangePasswordModel
    {
        
        [Required(ErrorMessage = "Please enter your current password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "Please enter your new password")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please enter your new password again")]
        [Display(Name = "New Password Again")]
        [Compare("NewPassword")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}
