using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }

        public ViewResult Aboutus()
        {
            return View();
        }
    }
}
