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
    public class VehicletypeController : Controller
    {
        private readonly automotivepartsContext _context;

        public VehicletypeController(automotivepartsContext context)
        {
            _context = context;
        }

        // GET: Vehicletype
        public async Task<IActionResult> Index()
        {
            var automotivepartsContext = _context.Vehicletype.Include(v => v.VehicleCategory);
            return View(await automotivepartsContext.ToListAsync());
        }

        // GET: Vehicletype/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicletype = await _context.Vehicletype
                .Include(v => v.VehicleCategory)
                .FirstOrDefaultAsync(m => m.VehicleTypeId == id);
            if (vehicletype == null)
            {
                return NotFound();
            }

            return View(vehicletype);
        }

        // GET: Vehicletype/Create
        public IActionResult Create()
        {
            ViewData["VehicleCategoryId"] = new SelectList(_context.Vehiclecategory, "VehicleCategoryId", "CreatedBy");
            return View();
        }

        // POST: Vehicletype/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleTypeId,Name,Description,VehicleCategoryId,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehicletype vehicletype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicletype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleCategoryId"] = new SelectList(_context.Vehiclecategory, "VehicleCategoryId", "CreatedBy", vehicletype.VehicleCategoryId);
            return View(vehicletype);
        }

        // GET: Vehicletype/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicletype = await _context.Vehicletype.FindAsync(id);
            if (vehicletype == null)
            {
                return NotFound();
            }
            ViewData["VehicleCategoryId"] = new SelectList(_context.Vehiclecategory, "VehicleCategoryId", "CreatedBy", vehicletype.VehicleCategoryId);
            return View(vehicletype);
        }

        // POST: Vehicletype/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleTypeId,Name,Description,VehicleCategoryId,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehicletype vehicletype)
        {
            if (id != vehicletype.VehicleTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicletype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicletypeExists(vehicletype.VehicleTypeId))
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
            ViewData["VehicleCategoryId"] = new SelectList(_context.Vehiclecategory, "VehicleCategoryId", "CreatedBy", vehicletype.VehicleCategoryId);
            return View(vehicletype);
        }

        // GET: Vehicletype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicletype = await _context.Vehicletype
                .Include(v => v.VehicleCategory)
                .FirstOrDefaultAsync(m => m.VehicleTypeId == id);
            if (vehicletype == null)
            {
                return NotFound();
            }

            return View(vehicletype);
        }

        // POST: Vehicletype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicletype = await _context.Vehicletype.FindAsync(id);
            _context.Vehicletype.Remove(vehicletype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicletypeExists(int id)
        {
            return _context.Vehicletype.Any(e => e.VehicleTypeId == id);
        }
    }
}
