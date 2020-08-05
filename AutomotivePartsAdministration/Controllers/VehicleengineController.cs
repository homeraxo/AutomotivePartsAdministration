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
        private readonly automotiveparts2Context _context;

        public VehicleengineController(automotiveparts2Context context)
        {
            _context = context;
        }

        // GET: Vehicleengine
        public async Task<IActionResult> Index()
        {
            var automotiveparts2Context = _context.Vehicleengine.Include(v => v.EngineCubicCentimeters).Include(v => v.EngineCylinderArrangement).Include(v => v.EngineLiter);
            return View(await automotiveparts2Context.ToListAsync());
        }

        // GET: Vehicleengine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleengine = await _context.Vehicleengine
                .Include(v => v.EngineCubicCentimeters)
                .Include(v => v.EngineCylinderArrangement)
                .Include(v => v.EngineLiter)
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
            ViewData["EngineCubicCentimetersId"] = new SelectList(_context.Enginecubiccentimeters, "EngineCubicCentimetersId", "CreatedBy");
            ViewData["EngineCylinderArrangementId"] = new SelectList(_context.Enginecylinderarrangement, "EngineCylinderArrangementId", "CreatedBy");
            ViewData["EngineLiterId"] = new SelectList(_context.Engineliter, "EngineLiterId", "CreatedBy");
            return View();
        }

        // POST: Vehicleengine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleEngineId,Name,Description,IsActive,EngineCylinderArrangementId,EngineLiterId,EngineCubicCentimetersId,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehicleengine vehicleengine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleengine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EngineCubicCentimetersId"] = new SelectList(_context.Enginecubiccentimeters, "EngineCubicCentimetersId", "CreatedBy", vehicleengine.EngineCubicCentimetersId);
            ViewData["EngineCylinderArrangementId"] = new SelectList(_context.Enginecylinderarrangement, "EngineCylinderArrangementId", "CreatedBy", vehicleengine.EngineCylinderArrangementId);
            ViewData["EngineLiterId"] = new SelectList(_context.Engineliter, "EngineLiterId", "CreatedBy", vehicleengine.EngineLiterId);
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
            ViewData["EngineCubicCentimetersId"] = new SelectList(_context.Enginecubiccentimeters, "EngineCubicCentimetersId", "CreatedBy", vehicleengine.EngineCubicCentimetersId);
            ViewData["EngineCylinderArrangementId"] = new SelectList(_context.Enginecylinderarrangement, "EngineCylinderArrangementId", "CreatedBy", vehicleengine.EngineCylinderArrangementId);
            ViewData["EngineLiterId"] = new SelectList(_context.Engineliter, "EngineLiterId", "CreatedBy", vehicleengine.EngineLiterId);
            return View(vehicleengine);
        }

        // POST: Vehicleengine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleEngineId,Name,Description,IsActive,EngineCylinderArrangementId,EngineLiterId,EngineCubicCentimetersId,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Vehicleengine vehicleengine)
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
            ViewData["EngineCubicCentimetersId"] = new SelectList(_context.Enginecubiccentimeters, "EngineCubicCentimetersId", "CreatedBy", vehicleengine.EngineCubicCentimetersId);
            ViewData["EngineCylinderArrangementId"] = new SelectList(_context.Enginecylinderarrangement, "EngineCylinderArrangementId", "CreatedBy", vehicleengine.EngineCylinderArrangementId);
            ViewData["EngineLiterId"] = new SelectList(_context.Engineliter, "EngineLiterId", "CreatedBy", vehicleengine.EngineLiterId);
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
                .Include(v => v.EngineCubicCentimeters)
                .Include(v => v.EngineCylinderArrangement)
                .Include(v => v.EngineLiter)
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
