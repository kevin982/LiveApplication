using BookStorePrueba.Models;
using BookStorePrueba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BookStorePrueba.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        private readonly IUserService _userService = null;
        private readonly IAccountService _accountService = null;
 

        public HomeController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }


        [Route("~/")]
        public async Task<ViewResult> Index()
        {
 

            ViewBag.IsAuthenticated = _userService.IsAuthenticated();
            ViewBag.Id = _userService.GetUserId();
            return View();
        }


        public ViewResult AboutUs()
        {
            return View();
        }


        public ViewResult ContactUs() => View();
    }
}
