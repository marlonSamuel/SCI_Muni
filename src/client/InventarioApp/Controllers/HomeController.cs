using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InventarioApp.Models;
using Microsoft.AspNetCore.Authorization;
using Common;

namespace InventarioApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICurrentUserFactory _currentUser;

        public HomeController(
            ICurrentUserFactory currentUser
        )
        {
            _currentUser = currentUser;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
