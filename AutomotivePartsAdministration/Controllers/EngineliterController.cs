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
    public class EngineliterController : Controller
    {
        private readonly automotiveparts2Context _context;

        public EngineliterController(automotiveparts2Context context)
        {
            _context = context;
        }

        // GET: Engineliter
        public async Task<IActionResult> Index()
        {
            return View(await _context.Engineliter.ToListAsync());
        }

        // GET: Engineliter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineliter = await _context.Engineliter
                .FirstOrDefaultAsync(m => m.EngineLiterId == id);
            if (engineliter == null)
            {
                return NotFound();
            }

            return View(engineliter);
        }

        // GET: Engineliter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Engineliter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngineLiterId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Engineliter engineliter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineliter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineliter);
        }

        // GET: Engineliter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineliter = await _context.Engineliter.FindAsync(id);
            if (engineliter == null)
            {
                return NotFound();
            }
            return View(engineliter);
        }

        // POST: Engineliter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EngineLiterId,Name,Description,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Engineliter engineliter)
        {
            if (id != engineliter.EngineLiterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineliter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineliterExists(engineliter.EngineLiterId))
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
            return View(engineliter);
        }

        // GET: Engineliter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineliter = await _context.Engineliter
                .FirstOrDefaultAsync(m => m.EngineLiterId == id);
            if (engineliter == null)
            {
                return NotFound();
            }

            return View(engineliter);
        }

        // POST: Engineliter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var engineliter = await _context.Engineliter.FindAsync(id);
            _context.Engineliter.Remove(engineliter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineliterExists(int id)
        {
            return _context.Engineliter.Any(e => e.EngineLiterId == id);
        }
    }
}
