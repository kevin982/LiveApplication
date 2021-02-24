using BookStorePrueba.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}
