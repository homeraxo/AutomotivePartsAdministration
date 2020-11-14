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
    public class EnginecylinderarrangementController : Controller
    {
        private readonly automotivepartsContext _context;

        public EnginecylinderarrangementController(automotivepartsContext context)
        {
            _context = context;
        }

        // GET: Enginecylinderarrangement
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enginecylinderarrangement.ToListAsync());
        }

        // GET: Enginecylinderarrangement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enginecylinderarrangement = await _context.Enginecylinderarrangement
                .FirstOrDefaultAsync(m => m.EngineCylinderArrangementId == id);
            if (enginecylinderarrangement == null)
            {
                return NotFound();
            }

            return View(enginecylinderarrangement);
        }

        // GET: Enginecylinderarrangement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enginecylinderarrangement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngineCylinderArrangementId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Enginecylinderarrangement enginecylinderarrangement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enginecylinderarrangement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enginecylinderarrangement);
        }

        // GET: Enginecylinderarrangement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enginecylinderarrangement = await _context.Enginecylinderarrangement.FindAsync(id);
            if (enginecylinderarrangement == null)
            {
                return NotFound();
            }
            return View(enginecylinderarrangement);
        }

        // POST: Enginecylinderarrangement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EngineCylinderArrangementId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Enginecylinderarrangement enginecylinderarrangement)
        {
            if (id != enginecylinderarrangement.EngineCylinderArrangementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enginecylinderarrangement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnginecylinderarrangementExists(enginecylinderarrangement.EngineCylinderArrangementId))
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
            return View(enginecylinderarrangement);
        }

        // GET: Enginecylinderarrangement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enginecylinderarrangement = await _context.Enginecylinderarrangement
                .FirstOrDefaultAsync(m => m.EngineCylinderArrangementId == id);
            if (enginecylinderarrangement == null)
            {
                return NotFound();
            }

            return View(enginecylinderarrangement);
        }

        // POST: Enginecylinderarrangement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enginecylinderarrangement = await _context.Enginecylinderarrangement.FindAsync(id);
            _context.Enginecylinderarrangement.Remove(enginecylinderarrangement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnginecylinderarrangementExists(int id)
        {
            return _context.Enginecylinderarrangement.Any(e => e.EngineCylinderArrangementId == id);
        }
    }
}
