using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealerLead.Web.Controllers
{
    public class DealerLeadUserController : Controller
    {
        private readonly DealerLeadDBContext _context;

        public DealerLeadUserController(DealerLeadDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

    }
}
