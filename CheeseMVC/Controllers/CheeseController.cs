﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        static private Dictionary<string, string> cheeses = new Dictionary<string, string>();

        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewBag.cheeses = cheeses;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            if (cheeses.ContainsKey(name))
                cheeses[name] = description;
            else
            {
                cheeses.Add(name, description);
            }

            return Redirect("/Cheese");
        }
    }
}
