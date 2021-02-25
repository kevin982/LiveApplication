using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Models.Tables
{

    //This class has been created to add some columns to our user table.
    public class UserTable:IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public DateTime Birthday { get; set; } = new();
    }
}
