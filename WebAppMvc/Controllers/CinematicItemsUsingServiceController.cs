using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMvc.Controllers
{
    public class CinematicItemsUsingServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}