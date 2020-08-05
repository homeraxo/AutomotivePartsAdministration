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
    public class VehicleController : Controller
    {
        private readonly automotiveparts2Context _context;

        public VehicleController(automotiveparts2Context context)
        {
            _context = context;
        }

        // GET: Vehicle
        public async Task<IActionResult> Index()
        {
            var automotiveparts2Context = _context.Vehicle.Include(v => v.VehicleCategory).Include(v => v.VehicleEngine).Include(v => v.VehicleManufacturer).Include(v => v.VehicleModel).Include(v => v.VehicleType);
            return View(await automotiveparts2Context.ToListAsync());
        }

        // GET: Vehicle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.VehicleCategory)
                .Include(v => v.VehicleEngine)
                .Include(v => v.VehicleManufacturer)
                .Include(v => v.VehicleModel)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicle/Create
        public IActionResult Create()
        {
            ViewData["VehicleCategoryId"] = new SelectList(_context.Vehiclecategory, "VehicleCategoryId", "CreatedBy");
            ViewData["VehicleEngineId"] = new SelectList(_context.Vehicleengine, "VehicleEngineId", "CreatedBy");
            ViewData["VehicleManufacturerId"] = new SelectList(_context.Vehiclemanufacturer, "VehicleManufacturerId", "CreatedBy");
            ViewData["VehicleModelId"] = new SelectList(_context.Vehiclemodel, "VehicleModelId", "CreatedBy");
            ViewData["VehicleTypeId"] = new SelectList(_context.Vehicletype, "VehicleTypeId", "CreatedBy");
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,Version,Cylinders,BeginYear,EndYear,EngineOilCapacity,Description,ImagePath,Link,SearchVehicle,IsActive,VehicleManufacturerId,VehicleModelId,VehicleCategoryId,VehicleEngineId,VehicleTypeId,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleCategoryId"] = new SelectList(_context.Vehiclecategory, "VehicleCategoryId", "CreatedBy", vehicle.VehicleCategoryId);
            ViewData["VehicleEngineId"] = new SelectList(_context.Vehicleengine, "VehicleEngineId", "CreatedBy", vehicle.VehicleEngineId);
            ViewData["VehicleManufacturerId"] = new SelectList(_context.Vehiclemanufacturer, "VehicleManufacturerId", "CreatedBy", vehicle.VehicleManufacturerId);
            ViewData["VehicleModelId"] = new SelectList(_context.Vehiclemodel, "VehicleModelId", "CreatedBy", vehicle.VehicleModelId);
            ViewData["VehicleTypeId"] = new SelectList(_context.Vehicletype, "VehicleTypeId", "CreatedBy", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["VehicleCategoryId"] = new SelectList(_context.Vehiclecategory, "VehicleCategoryId", "CreatedBy", vehicle.VehicleCategoryId);
            ViewData["VehicleEngineId"] = new SelectList(_context.Vehicleengine, "VehicleEngineId", "CreatedBy", vehicle.VehicleEngineId);
            ViewData["VehicleManufacturerId"] = new SelectList(_context.Vehiclemanufacturer, "VehicleManufacturerId", "CreatedBy", vehicle.VehicleManufacturerId);
            ViewData["VehicleModelId"] = new SelectList(_context.Vehiclemodel, "VehicleModelId", "CreatedBy", vehicle.VehicleModelId);
            ViewData["VehicleTypeId"] = new SelectList(_context.Vehicletype, "VehicleTypeId", "CreatedBy", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,Version,Cylinders,BeginYear,EndYear,EngineOilCapacity,Description,ImagePath,Link,SearchVehicle,IsActive,VehicleManufacturerId,VehicleModelId,VehicleCategoryId,VehicleEngineId,VehicleTypeId,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleId))
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
            ViewData["VehicleCategoryId"] = new SelectList(_context.Vehiclecategory, "VehicleCategoryId", "CreatedBy", vehicle.VehicleCategoryId);
            ViewData["VehicleEngineId"] = new SelectList(_context.Vehicleengine, "VehicleEngineId", "CreatedBy", vehicle.VehicleEngineId);
            ViewData["VehicleManufacturerId"] = new SelectList(_context.Vehiclemanufacturer, "VehicleManufacturerId", "CreatedBy", vehicle.VehicleManufacturerId);
            ViewData["VehicleModelId"] = new SelectList(_context.Vehiclemodel, "VehicleModelId", "CreatedBy", vehicle.VehicleModelId);
            ViewData["VehicleTypeId"] = new SelectList(_context.Vehicletype, "VehicleTypeId", "CreatedBy", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.VehicleCategory)
                .Include(v => v.VehicleEngine)
                .Include(v => v.VehicleManufacturer)
                .Include(v => v.VehicleModel)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.VehicleId == id);
        }
    }
}
