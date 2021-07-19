using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DealerLead;

namespace DealerLead.Web.Controllers
{
    public class SupportedMakesController : Controller
    {
        private readonly DealerLeadDBContext _context;

        public SupportedMakesController(DealerLeadDBContext context)
        {
            _context = context;
        }

        // GET: SupportedMakes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupportedMake.ToListAsync());
        }

        // GET: SupportedMakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedMakes = await _context.SupportedMake
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportedMakes == null)
            {
                return NotFound();
            }

            return View(supportedMakes);
        }

        // GET: SupportedMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportedMakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] SupportedMakes supportedMakes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportedMakes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportedMakes);
        }

        // GET: SupportedMakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedMakes = await _context.SupportedMake.FindAsync(id);
            if (supportedMakes == null)
            {
                return NotFound();
            }
            return View(supportedMakes);
        }

        // POST: SupportedMakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] SupportedMakes supportedMakes)
        {
            if (id != supportedMakes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    supportedMakes.ModifyDate = DateTime.Now;
                    _context.Update(supportedMakes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportedMakesExists(supportedMakes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supportedMakes);
        }

        // GET: SupportedMakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedMakes = await _context.SupportedMake
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportedMakes == null)
            {
                return NotFound();
            }

            return View(supportedMakes);
        }

        // POST: SupportedMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportedMakes = await _context.SupportedMake.FindAsync(id);
            _context.SupportedMake.Remove(supportedMakes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportedMakesExists(int id)
        {
            return _context.SupportedMake.Any(e => e.Id == id);
        }
    }
}
