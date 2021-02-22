using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController:Controller
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
