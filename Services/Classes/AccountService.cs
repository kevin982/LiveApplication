using BookStorePrueba.Data.Context;
using BookStorePrueba.Models;
using BookStorePrueba.Models.Tables;
using BookStorePrueba.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BookStorePrueba.Services.Classes
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<UserTable> _userManager = null;
        private readonly SignInManager<UserTable> _signInManager = null;
        private readonly RoleManager<IdentityRole> _roleManager = null;
        private readonly IUserService _userService = null;
        private readonly IEmailService _emailService = null;

        public AccountService(UserManager<UserTable> userManager, SignInManager<UserTable> signInManager, RoleManager<IdentityRole> roleManager, IUserService userService, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            var role = await _roleManager.FindByNameAsync("Admin");
            await _roleManager.DeleteAsync(role);
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

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                if (!string.IsNullOrEmpty(token))
                {
                    await SendEmailConfirmation(user, token);
                }

            }

            return result;
        }

        private async Task SendEmailConfirmation(UserTable user, string token)
        {
            string htmlPath = "C:\\Users\\admin\\Desktop\\BookStorePrueba\\Emails\\ConfirmEmail.html";
            string subject = "Email Verification";
            List<Attachment> attachments = new();
            List<string> mails = new() { user.Email };
            List<(string, string)> data = new() { ("Link", string.Format("http://localhost:63674" + $"/ConfirmEmail?id={user.Id}&token={token}")), ("UserName", user.FirstName) };

            await _emailService.SendEmailAsync(htmlPath, subject, attachments, mails, data);
        }


        public async Task<IdentityResult> ConfirmEmailAsync(string id, string token)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<SignInResult> SignInAsync(SignInUserModel signInUserModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInUserModel.Email, signInUserModel.Password, signInUserModel.RememberMe, true);
 
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

        public async Task GenerateForgotPasswordTokenAsync(ForgotPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailForgotPassword(user, token);
            }
        }

        private async Task SendEmailForgotPassword(UserTable user, string token)
        {
            string htmlPath = "C:\\Users\\admin\\Desktop\\BookStorePrueba\\Emails\\ForgotPassword.html";
            string subject = "ForgotPassword";
            List<Attachment> attachments = new();
            List<string> mails = new() { user.Email };
            List<(string, string)> data = new() { ("Link", string.Format("http://localhost:63674" + $"/ResetPassword?id={user.Id}&token={token}")), ("UserName", user.FirstName) };

            await _emailService.SendEmailAsync(htmlPath, subject, attachments, mails, data);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            
            

            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
        }

    }
}
