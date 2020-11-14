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
    public class ProductbrandController : Controller
    {
        private readonly automotivepartsContext _context;

        public ProductbrandController(automotivepartsContext context)
        {
            _context = context;
        }

        // GET: Productbrand
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productbrand.ToListAsync());
        }

        // GET: Productbrand/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productbrand = await _context.Productbrand
                .FirstOrDefaultAsync(m => m.ProductBrandId == id);
            if (productbrand == null)
            {
                return NotFound();
            }

            return View(productbrand);
        }

        // GET: Productbrand/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productbrand/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductBrandId,Name,Description,ImagePath,Link,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Productbrand productbrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productbrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productbrand);
        }

        // GET: Productbrand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productbrand = await _context.Productbrand.FindAsync(id);
            if (productbrand == null)
            {
                return NotFound();
            }
            return View(productbrand);
        }

        // POST: Productbrand/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductBrandId,Name,Description,ImagePath,Link,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Productbrand productbrand)
        {
            if (id != productbrand.ProductBrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productbrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductbrandExists(productbrand.ProductBrandId))
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
            return View(productbrand);
        }

        // GET: Productbrand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productbrand = await _context.Productbrand
                .FirstOrDefaultAsync(m => m.ProductBrandId == id);
            if (productbrand == null)
            {
                return NotFound();
            }

            return View(productbrand);
        }

        // POST: Productbrand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productbrand = await _context.Productbrand.FindAsync(id);
            _context.Productbrand.Remove(productbrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductbrandExists(int id)
        {
            return _context.Productbrand.Any(e => e.ProductBrandId == id);
        }
    }
}
