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
    public class ProductpresentationController : Controller
    {
        private readonly automotivepartsContext _context;

        public ProductpresentationController(automotivepartsContext context)
        {
            _context = context;
        }

        // GET: Productpresentation
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productpresentation.ToListAsync());
        }

        // GET: Productpresentation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productpresentation = await _context.Productpresentation
                .FirstOrDefaultAsync(m => m.ProductPresentationId == id);
            if (productpresentation == null)
            {
                return NotFound();
            }

            return View(productpresentation);
        }

        // GET: Productpresentation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productpresentation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductPresentationId,Name,Description,ImagePath,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Productpresentation productpresentation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productpresentation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productpresentation);
        }

        // GET: Productpresentation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productpresentation = await _context.Productpresentation.FindAsync(id);
            if (productpresentation == null)
            {
                return NotFound();
            }
            return View(productpresentation);
        }

        // POST: Productpresentation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductPresentationId,Name,Description,ImagePath,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Productpresentation productpresentation)
        {
            if (id != productpresentation.ProductPresentationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productpresentation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductpresentationExists(productpresentation.ProductPresentationId))
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
            return View(productpresentation);
        }

        // GET: Productpresentation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productpresentation = await _context.Productpresentation
                .FirstOrDefaultAsync(m => m.ProductPresentationId == id);
            if (productpresentation == null)
            {
                return NotFound();
            }

            return View(productpresentation);
        }

        // POST: Productpresentation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productpresentation = await _context.Productpresentation.FindAsync(id);
            _context.Productpresentation.Remove(productpresentation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductpresentationExists(int id)
        {
            return _context.Productpresentation.Any(e => e.ProductPresentationId == id);
        }
    }
}
