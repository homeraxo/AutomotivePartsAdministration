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
    public class EnginesizeController : Controller
    {
        private readonly automotivepartsContext _context;

        public EnginesizeController(automotivepartsContext context)
        {
            _context = context;
        }

        // GET: Enginesize
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enginesize.ToListAsync());
        }

        // GET: Enginesize/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enginesize = await _context.Enginesize
                .FirstOrDefaultAsync(m => m.EngineSizeId == id);
            if (enginesize == null)
            {
                return NotFound();
            }

            return View(enginesize);
        }

        // GET: Enginesize/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enginesize/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngineSizeId,Liter,CubicCentimeters,CubicInches,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Enginesize enginesize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enginesize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enginesize);
        }

        // GET: Enginesize/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enginesize = await _context.Enginesize.FindAsync(id);
            if (enginesize == null)
            {
                return NotFound();
            }
            return View(enginesize);
        }

        // POST: Enginesize/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EngineSizeId,Liter,CubicCentimeters,CubicInches,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Enginesize enginesize)
        {
            if (id != enginesize.EngineSizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enginesize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnginesizeExists(enginesize.EngineSizeId))
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
            return View(enginesize);
        }

        // GET: Enginesize/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enginesize = await _context.Enginesize
                .FirstOrDefaultAsync(m => m.EngineSizeId == id);
            if (enginesize == null)
            {
                return NotFound();
            }

            return View(enginesize);
        }

        // POST: Enginesize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enginesize = await _context.Enginesize.FindAsync(id);
            _context.Enginesize.Remove(enginesize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnginesizeExists(int id)
        {
            return _context.Enginesize.Any(e => e.EngineSizeId == id);
        }
    }
}
