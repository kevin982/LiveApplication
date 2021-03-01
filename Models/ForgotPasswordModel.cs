using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Models
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress, Display(Name = "Required email adress")]

        public string Email { get; set; } = string.Empty;

        public bool EmailSent { get; set; }
    }
}
