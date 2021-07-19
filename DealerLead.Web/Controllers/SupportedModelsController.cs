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
    public class SupportedModelsController : Controller
    {
        private readonly DealerLeadDBContext _context;

        public SupportedModelsController(DealerLeadDBContext context)
        {
            _context = context;
        }

        // GET: SupportedModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupportedModel.ToListAsync());
        }

        // GET: SupportedModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedModels = await _context.SupportedModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportedModels == null)
            {
                return NotFound();
            }

            return View(supportedModels);
        }

        // GET: SupportedModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportedModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,MakeId")] SupportedModels supportedModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportedModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportedModels);
        }

        // GET: SupportedModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedModels = await _context.SupportedModel.FindAsync(id);
            if (supportedModels == null)
            {
                return NotFound();
            }
            return View(supportedModels);
        }

        // POST: SupportedModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MakeId")] SupportedModels supportedModels)
        {
            if (id != supportedModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportedModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportedModelsExists(supportedModels.Id))
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
            return View(supportedModels);
        }

        // GET: SupportedModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedModels = await _context.SupportedModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportedModels == null)
            {
                return NotFound();
            }

            return View(supportedModels);
        }

        // POST: SupportedModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportedModels = await _context.SupportedModel.FindAsync(id);
            _context.SupportedModel.Remove(supportedModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportedModelsExists(int id)
        {
            return _context.SupportedModel.Any(e => e.Id == id);
        }
    }
}
