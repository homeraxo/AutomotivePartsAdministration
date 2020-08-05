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
    public class VehiclemanufacturerController : Controller
    {
        private readonly automotiveparts2Context _context;

        public VehiclemanufacturerController(automotiveparts2Context context)
        {
            _context = context;
        }

        // GET: Vehiclemanufacturer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehiclemanufacturer.ToListAsync());
        }

        // GET: Vehiclemanufacturer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclemanufacturer = await _context.Vehiclemanufacturer
                .FirstOrDefaultAsync(m => m.VehicleManufacturerId == id);
            if (vehiclemanufacturer == null)
            {
                return NotFound();
            }

            return View(vehiclemanufacturer);
        }

        // GET: Vehiclemanufacturer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiclemanufacturer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleManufacturerId,ShortName,FullName,Description,ImagePath,Link,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehiclemanufacturer vehiclemanufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiclemanufacturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiclemanufacturer);
        }

        // GET: Vehiclemanufacturer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclemanufacturer = await _context.Vehiclemanufacturer.FindAsync(id);
            if (vehiclemanufacturer == null)
            {
                return NotFound();
            }
            return View(vehiclemanufacturer);
        }

        // POST: Vehiclemanufacturer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleManufacturerId,ShortName,FullName,Description,ImagePath,Link,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehiclemanufacturer vehiclemanufacturer)
        {
            if (id != vehiclemanufacturer.VehicleManufacturerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiclemanufacturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclemanufacturerExists(vehiclemanufacturer.VehicleManufacturerId))
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
            return View(vehiclemanufacturer);
        }

        // GET: Vehiclemanufacturer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclemanufacturer = await _context.Vehiclemanufacturer
                .FirstOrDefaultAsync(m => m.VehicleManufacturerId == id);
            if (vehiclemanufacturer == null)
            {
                return NotFound();
            }

            return View(vehiclemanufacturer);
        }

        // POST: Vehiclemanufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiclemanufacturer = await _context.Vehiclemanufacturer.FindAsync(id);
            _context.Vehiclemanufacturer.Remove(vehiclemanufacturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclemanufacturerExists(int id)
        {
            return _context.Vehiclemanufacturer.Any(e => e.VehicleManufacturerId == id);
        }
    }
}
