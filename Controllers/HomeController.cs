using BookStorePrueba.Models;
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

        [Route("~/")]
        public ViewResult Index()
        {
            return View();
        }


        public ViewResult AboutUs()
        {
            return View();
        }


        public ViewResult ContactUs() => View();
    }
}
