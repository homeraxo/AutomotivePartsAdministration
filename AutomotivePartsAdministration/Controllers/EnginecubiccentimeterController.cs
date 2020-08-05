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
    public class EnginecubiccentimeterController : Controller
    {
        private readonly automotiveparts2Context _context;

        public EnginecubiccentimeterController(automotiveparts2Context context)
        {
            _context = context;
        }

        // GET: Enginecubiccentimeter
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enginecubiccentimeters.ToListAsync());
        }

        // GET: Enginecubiccentimeter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enginecubiccentimeters = await _context.Enginecubiccentimeters
                .FirstOrDefaultAsync(m => m.EngineCubicCentimetersId == id);
            if (enginecubiccentimeters == null)
            {
                return NotFound();
            }

            return View(enginecubiccentimeters);
        }

        // GET: Enginecubiccentimeter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enginecubiccentimeter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngineCubicCentimetersId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Enginecubiccentimeters enginecubiccentimeters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enginecubiccentimeters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enginecubiccentimeters);
        }

        // GET: Enginecubiccentimeter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enginecubiccentimeters = await _context.Enginecubiccentimeters.FindAsync(id);
            if (enginecubiccentimeters == null)
            {
                return NotFound();
            }
            return View(enginecubiccentimeters);
        }

        // POST: Enginecubiccentimeter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EngineCubicCentimetersId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Enginecubiccentimeters enginecubiccentimeters)
        {
            if (id != enginecubiccentimeters.EngineCubicCentimetersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enginecubiccentimeters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnginecubiccentimetersExists(enginecubiccentimeters.EngineCubicCentimetersId))
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
            return View(enginecubiccentimeters);
        }

        // GET: Enginecubiccentimeter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enginecubiccentimeters = await _context.Enginecubiccentimeters
                .FirstOrDefaultAsync(m => m.EngineCubicCentimetersId == id);
            if (enginecubiccentimeters == null)
            {
                return NotFound();
            }

            return View(enginecubiccentimeters);
        }

        // POST: Enginecubiccentimeter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enginecubiccentimeters = await _context.Enginecubiccentimeters.FindAsync(id);
            _context.Enginecubiccentimeters.Remove(enginecubiccentimeters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnginecubiccentimetersExists(int id)
        {
            return _context.Enginecubiccentimeters.Any(e => e.EngineCubicCentimetersId == id);
        }
    }
}
