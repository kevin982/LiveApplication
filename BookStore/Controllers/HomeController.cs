﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController:Controller
    {
        public string Index()
        {
            return "Hi I am in the index";
        }

        public string Saludar()
        {
            return "Hola estoy saludando";
        }
    }
}
