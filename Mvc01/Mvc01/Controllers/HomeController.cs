﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc01.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("index");
        }

        //public IActionResult Yrittää()
        //{
        //    return View("yrittää");
        //}

    }
}
