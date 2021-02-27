using BookStorePrueba.Models;
using BookStorePrueba.Services.Classes;
using BookStorePrueba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService = null;
        

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult SignUp()
        {
            return View();
        }

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

        public IActionResult SignIn() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserModel signInUserModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.SignInAsync(signInUserModel);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Invalid credentials");
                    return View(signInUserModel);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            return View();

        }

        public async Task<IActionResult> SignOut()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ChangePassword()
        {
            ViewBag.Succeded= null;
            ViewBag.Errors = null;
            return View();
        }

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

    }
}
