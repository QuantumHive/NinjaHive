﻿using System.Web.Mvc;

namespace NinjaHive.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}