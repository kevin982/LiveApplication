using BookStorePrueba.Models;
using BookStorePrueba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        private readonly IUserService _userService = null;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }


        [Route("~/")]
        public ViewResult Index()
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
