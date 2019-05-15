using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilkyWay.Data;
using MilkyWay.Models;

namespace MilkyWay.Controllers
{
    public class CarbrandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarbrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carbrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carbrands.ToListAsync());
        }

        // GET: Carbrands/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carbrand = await _context.Carbrands
                .FirstOrDefaultAsync(m => m.Name == id);
            if (carbrand == null)
            {
                return NotFound();
            }

            return View(carbrand);
        }

        // GET: Carbrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carbrands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Carbrand carbrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carbrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carbrand);
        }

        // GET: Carbrands/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carbrand = await _context.Carbrands.FindAsync(id);
            if (carbrand == null)
            {
                return NotFound();
            }
            return View(carbrand);
        }

        // POST: Carbrands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] Carbrand carbrand)
        {
            if (id != carbrand.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carbrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarbrandExists(carbrand.Name))
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
            return View(carbrand);
        }

        // GET: Carbrands/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carbrand = await _context.Carbrands
                .FirstOrDefaultAsync(m => m.Name == id);
            if (carbrand == null)
            {
                return NotFound();
            }

            return View(carbrand);
        }

        // POST: Carbrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var carbrand = await _context.Carbrands.FindAsync(id);
            _context.Carbrands.Remove(carbrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarbrandExists(string id)
        {
            return _context.Carbrands.Any(e => e.Name == id);
        }
    }
}
