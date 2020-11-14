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
    public class ProductcodeController : Controller
    {
        private readonly automotivepartsContext _context;

        public ProductcodeController(automotivepartsContext context)
        {
            _context = context;
        }

        // GET: Productcode
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productcode.ToListAsync());
        }

        // GET: Productcode/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productcode = await _context.Productcode
                .FirstOrDefaultAsync(m => m.ProductCodeId == id);
            if (productcode == null)
            {
                return NotFound();
            }

            return View(productcode);
        }

        // GET: Productcode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productcode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCodeId,Name,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Productcode productcode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productcode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productcode);
        }

        // GET: Productcode/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productcode = await _context.Productcode.FindAsync(id);
            if (productcode == null)
            {
                return NotFound();
            }
            return View(productcode);
        }

        // POST: Productcode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCodeId,Name,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Productcode productcode)
        {
            if (id != productcode.ProductCodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productcode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductcodeExists(productcode.ProductCodeId))
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
            return View(productcode);
        }

        // GET: Productcode/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productcode = await _context.Productcode
                .FirstOrDefaultAsync(m => m.ProductCodeId == id);
            if (productcode == null)
            {
                return NotFound();
            }

            return View(productcode);
        }

        // POST: Productcode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productcode = await _context.Productcode.FindAsync(id);
            _context.Productcode.Remove(productcode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductcodeExists(int id)
        {
            return _context.Productcode.Any(e => e.ProductCodeId == id);
        }
    }
}
