using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Headers;
using System.IO;
using MuseumManagementSystem.Controllers;
using MuseumManagementSystem.Data;

namespace MuseumManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MuseumManagementSystemDbContext _context;

        public AdminController(ILogger<HomeController> logger, MuseumManagementSystemDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
           return View();
        }
    }
}