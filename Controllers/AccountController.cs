using BookStorePrueba.Models;
using BookStorePrueba.Services.Classes;
using BookStorePrueba.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Controllers
{

    public class AccountController : Controller
    {

        private readonly IAccountService _accountService = null;


        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string id, string token)
        {
            ViewBag.Errors = new List<string>();

            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');

                var result = await _accountService.ConfirmEmailAsync(id, token);

                foreach (var error in result.Errors) ViewBag.Errors.Add(error.Description);

            }

            return View();
        }

        [Route("Account/SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }


        [Route("Account/SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel userModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _accountService.CreateUserAsync(userModel);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View(userModel);

            }

            return View();
        }

        [Route("Account/SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [Route("Account/SignIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserModel signInUserModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.SignInAsync(signInUserModel);

                if (!result.Succeeded)
                {

                    if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError("", "Not allowed");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid credentials");
                    }

                    return View(signInUserModel);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            return View();

        }

        [Route("Account/SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("Account/ChangePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            ViewBag.Succeded = null;
            ViewBag.Errors = null;
            return View();
        }

        [Route("Account/ChangePassword")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePassword)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.ChangePasswordAsync(changePassword);
                ViewBag.Succeded = result.Succeeded;
                ViewBag.Errors = result.Errors;
            }

            return View();
        }


        [AllowAnonymous, HttpGet("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        [AllowAnonymous, HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            { 
                await _accountService.GenerateForgotPasswordTokenAsync(model);

                ModelState.Clear();
                model.EmailSent = true;
            }
            return View(model);
        }

        [AllowAnonymous, HttpGet("ResetPassword")]
        public IActionResult ResetPassword(string id, string token)
        {
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                Token = token,
                UserId = id
            };
            return View(resetPasswordModel);
        }

        [AllowAnonymous, HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(' ', '+');
                var result = await _accountService.ResetPasswordAsync(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

    }
}
