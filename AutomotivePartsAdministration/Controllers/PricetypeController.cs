using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomotivePartsAdministration.automotiveparts;

namespace AutomotivePartsAdministration.Controllers
{
    public class PricetypeController : Controller
    {
        private readonly automotivepartsContext _context;

        public PricetypeController(automotivepartsContext context)
        {
            _context = context;
        }

        // GET: Pricetype
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pricetype.ToListAsync());
        }

        // GET: Pricetype/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricetype = await _context.Pricetype
                .FirstOrDefaultAsync(m => m.PriceTypeId == id);
            if (pricetype == null)
            {
                return NotFound();
            }

            return View(pricetype);
        }

        // GET: Pricetype/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pricetype/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PriceTypeId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Pricetype pricetype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pricetype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pricetype);
        }

        // GET: Pricetype/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricetype = await _context.Pricetype.FindAsync(id);
            if (pricetype == null)
            {
                return NotFound();
            }
            return View(pricetype);
        }

        // POST: Pricetype/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PriceTypeId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Pricetype pricetype)
        {
            if (id != pricetype.PriceTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pricetype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PricetypeExists(pricetype.PriceTypeId))
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
            return View(pricetype);
        }

        // GET: Pricetype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricetype = await _context.Pricetype
                .FirstOrDefaultAsync(m => m.PriceTypeId == id);
            if (pricetype == null)
            {
                return NotFound();
            }

            return View(pricetype);
        }

        // POST: Pricetype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pricetype = await _context.Pricetype.FindAsync(id);
            _context.Pricetype.Remove(pricetype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PricetypeExists(int id)
        {
            return _context.Pricetype.Any(e => e.PriceTypeId == id);
        }
    }
}
