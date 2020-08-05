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
    public class VehiclemodelController : Controller
    {
        private readonly automotiveparts2Context _context;

        public VehiclemodelController(automotiveparts2Context context)
        {
            _context = context;
        }

        // GET: Vehiclemodel
        public async Task<IActionResult> Index()
        {
            var automotiveparts2Context = _context.Vehiclemodel.Include(v => v.VehicleManufacturer);
            return View(await automotiveparts2Context.ToListAsync());
        }

        // GET: Vehiclemodel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclemodel = await _context.Vehiclemodel
                .Include(v => v.VehicleManufacturer)
                .FirstOrDefaultAsync(m => m.VehicleModelId == id);
            if (vehiclemodel == null)
            {
                return NotFound();
            }

            return View(vehiclemodel);
        }

        // GET: Vehiclemodel/Create
        public IActionResult Create()
        {
            ViewData["VehicleManufacturerId"] = new SelectList(_context.Vehiclemanufacturer, "VehicleManufacturerId", "CreatedBy");
            return View();
        }

        // POST: Vehiclemodel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleModelId,Name,Description,IsActive,VehicleManufacturerId,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehiclemodel vehiclemodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiclemodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleManufacturerId"] = new SelectList(_context.Vehiclemanufacturer, "VehicleManufacturerId", "CreatedBy", vehiclemodel.VehicleManufacturerId);
            return View(vehiclemodel);
        }

        // GET: Vehiclemodel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclemodel = await _context.Vehiclemodel.FindAsync(id);
            if (vehiclemodel == null)
            {
                return NotFound();
            }
            ViewData["VehicleManufacturerId"] = new SelectList(_context.Vehiclemanufacturer, "VehicleManufacturerId", "CreatedBy", vehiclemodel.VehicleManufacturerId);
            return View(vehiclemodel);
        }

        // POST: Vehiclemodel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleModelId,Name,Description,IsActive,VehicleManufacturerId,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehiclemodel vehiclemodel)
        {
            if (id != vehiclemodel.VehicleModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiclemodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclemodelExists(vehiclemodel.VehicleModelId))
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
            ViewData["VehicleManufacturerId"] = new SelectList(_context.Vehiclemanufacturer, "VehicleManufacturerId", "CreatedBy", vehiclemodel.VehicleManufacturerId);
            return View(vehiclemodel);
        }

        // GET: Vehiclemodel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclemodel = await _context.Vehiclemodel
                .Include(v => v.VehicleManufacturer)
                .FirstOrDefaultAsync(m => m.VehicleModelId == id);
            if (vehiclemodel == null)
            {
                return NotFound();
            }

            return View(vehiclemodel);
        }

        // POST: Vehiclemodel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiclemodel = await _context.Vehiclemodel.FindAsync(id);
            _context.Vehiclemodel.Remove(vehiclemodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclemodelExists(int id)
        {
            return _context.Vehiclemodel.Any(e => e.VehicleModelId == id);
        }
    }
}
