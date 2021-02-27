using BookStorePrueba.Models;
using BookStorePrueba.Models.Tables;
using BookStorePrueba.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Services.Classes
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<UserTable> _userManager = null;
        private readonly SignInManager<UserTable> _signInManager = null;
        private readonly IUserService _userService = null;

        public AccountService(UserManager<UserTable> userManager, SignInManager<UserTable> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new UserTable()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Birthday = userModel.Birthday,
                Age = userModel.Age,
                Email = userModel.Email,
                UserName = userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<SignInResult> SignInAsync(SignInUserModel signInUserModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInUserModel.Email, signInUserModel.Password, signInUserModel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        { 
   
            var userId = _userService.GetUserId(); //We get the user Id.
            var user = await _userManager.FindByIdAsync(userId); //We get all the information about the user.
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);//We change the password
        }

    }
}
