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
    public class VehicleengineController : Controller
    {
        private readonly automotivepartsContext _context;

        public VehicleengineController(automotivepartsContext context)
        {
            _context = context;
        }

        // GET: Vehicleengine
        public async Task<IActionResult> Index()
        {
            var automotivepartsContext = _context.Vehicleengine.Include(v => v.EngineCylinderArrangement).Include(v => v.EngineSize);
            return View(await automotivepartsContext.ToListAsync());
        }

        // GET: Vehicleengine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleengine = await _context.Vehicleengine
                .Include(v => v.EngineCylinderArrangement)
                .Include(v => v.EngineSize)
                .FirstOrDefaultAsync(m => m.VehicleEngineId == id);
            if (vehicleengine == null)
            {
                return NotFound();
            }

            return View(vehicleengine);
        }

        // GET: Vehicleengine/Create
        public IActionResult Create()
        {
            ViewData["EngineCylinderArrangementId"] = new SelectList(_context.Enginecylinderarrangement, "EngineCylinderArrangementId", "CreatedBy");
            ViewData["EngineSizeId"] = new SelectList(_context.Enginesize, "EngineSizeId", "CreatedBy");
            return View();
        }

        // POST: Vehicleengine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleEngineId,Name,Description,IsActive,EngineCylinderArrangementId,EngineSizeId,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehicleengine vehicleengine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleengine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EngineCylinderArrangementId"] = new SelectList(_context.Enginecylinderarrangement, "EngineCylinderArrangementId", "CreatedBy", vehicleengine.EngineCylinderArrangementId);
            ViewData["EngineSizeId"] = new SelectList(_context.Enginesize, "EngineSizeId", "CreatedBy", vehicleengine.EngineSizeId);
            return View(vehicleengine);
        }

        // GET: Vehicleengine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleengine = await _context.Vehicleengine.FindAsync(id);
            if (vehicleengine == null)
            {
                return NotFound();
            }
            ViewData["EngineCylinderArrangementId"] = new SelectList(_context.Enginecylinderarrangement, "EngineCylinderArrangementId", "CreatedBy", vehicleengine.EngineCylinderArrangementId);
            ViewData["EngineSizeId"] = new SelectList(_context.Enginesize, "EngineSizeId", "CreatedBy", vehicleengine.EngineSizeId);
            return View(vehicleengine);
        }

        // POST: Vehicleengine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleEngineId,Name,Description,IsActive,EngineCylinderArrangementId,EngineSizeId,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehicleengine vehicleengine)
        {
            if (id != vehicleengine.VehicleEngineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleengine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleengineExists(vehicleengine.VehicleEngineId))
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
            ViewData["EngineCylinderArrangementId"] = new SelectList(_context.Enginecylinderarrangement, "EngineCylinderArrangementId", "CreatedBy", vehicleengine.EngineCylinderArrangementId);
            ViewData["EngineSizeId"] = new SelectList(_context.Enginesize, "EngineSizeId", "CreatedBy", vehicleengine.EngineSizeId);
            return View(vehicleengine);
        }

        // GET: Vehicleengine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleengine = await _context.Vehicleengine
                .Include(v => v.EngineCylinderArrangement)
                .Include(v => v.EngineSize)
                .FirstOrDefaultAsync(m => m.VehicleEngineId == id);
            if (vehicleengine == null)
            {
                return NotFound();
            }

            return View(vehicleengine);
        }

        // POST: Vehicleengine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleengine = await _context.Vehicleengine.FindAsync(id);
            _context.Vehicleengine.Remove(vehicleengine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleengineExists(int id)
        {
            return _context.Vehicleengine.Any(e => e.VehicleEngineId == id);
        }
    }
}
