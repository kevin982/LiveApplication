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
    }
}
