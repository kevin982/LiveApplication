using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        public IActionResult SignUp()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult SignUp(SignUpUserModel userModel)
        {

            if (ModelState.IsValid)
            {

            }

            return View();
        }
    }
}
