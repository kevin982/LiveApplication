using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController:Controller
    {
        [ViewData]
        public string Title { get; set; }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Aboutus()
        {
            return View();
        }

        public ViewResult ContactUs() => View();
    }
}
