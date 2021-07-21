using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DealerLead.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace DealerLead.Web.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DealerLeadDBContext _context;


        public HomeController(ILogger<HomeController> logger, DealerLeadDBContext context)
        {
            _logger = logger;
            _context = context;
        }



        [AllowAnonymous]
        public IActionResult Index()
        {
            var user = this.User;

            ViewBag.isAuthenticatedUser = user.Identity.IsAuthenticated;
            if (user.Identity.IsAuthenticated)
            {
                ViewBag.oid = GetOid();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(string oid)
        {
            var newUser = new DealerLeadUser();
            newUser.AzureId = Guid.Parse(oid);
            await _context.AddAsync<DealerLeadUser>(newUser);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private Guid? GetOid()
        {
            var identity = (ClaimsIdentity)User.Identity;
            if (identity == null)
            {
                return null;
            }
            else
            {
                string oid = identity.Claims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").Value;

                return Guid.Parse(oid);
            }
            
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
