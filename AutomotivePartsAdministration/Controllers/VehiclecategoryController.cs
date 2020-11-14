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
    public class VehiclecategoryController : Controller
    {
        private readonly automotivepartsContext _context;

        public VehiclecategoryController(automotivepartsContext context)
        {
            _context = context;
        }

        // GET: Vehiclecategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehiclecategory.ToListAsync());
        }

        // GET: Vehiclecategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclecategory = await _context.Vehiclecategory
                .FirstOrDefaultAsync(m => m.VehicleCategoryId == id);
            if (vehiclecategory == null)
            {
                return NotFound();
            }

            return View(vehiclecategory);
        }

        // GET: Vehiclecategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiclecategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleCategoryId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehiclecategory vehiclecategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiclecategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiclecategory);
        }

        // GET: Vehiclecategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclecategory = await _context.Vehiclecategory.FindAsync(id);
            if (vehiclecategory == null)
            {
                return NotFound();
            }
            return View(vehiclecategory);
        }

        // POST: Vehiclecategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleCategoryId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehiclecategory vehiclecategory)
        {
            if (id != vehiclecategory.VehicleCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiclecategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclecategoryExists(vehiclecategory.VehicleCategoryId))
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
            return View(vehiclecategory);
        }

        // GET: Vehiclecategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclecategory = await _context.Vehiclecategory
                .FirstOrDefaultAsync(m => m.VehicleCategoryId == id);
            if (vehiclecategory == null)
            {
                return NotFound();
            }

            return View(vehiclecategory);
        }

        // POST: Vehiclecategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiclecategory = await _context.Vehiclecategory.FindAsync(id);
            _context.Vehiclecategory.Remove(vehiclecategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclecategoryExists(int id)
        {
            return _context.Vehiclecategory.Any(e => e.VehicleCategoryId == id);
        }
    }
}
