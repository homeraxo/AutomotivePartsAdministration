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
    public class ProducttypeController : Controller
    {
        private readonly automotiveparts2Context _context;

        public ProducttypeController(automotiveparts2Context context)
        {
            _context = context;
        }

        // GET: Producttype
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producttype.ToListAsync());
        }

        // GET: Producttype/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producttype = await _context.Producttype
                .FirstOrDefaultAsync(m => m.ProductTypeId == id);
            if (producttype == null)
            {
                return NotFound();
            }

            return View(producttype);
        }

        // GET: Producttype/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producttype/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductTypeId,Name,Description,ImagePath,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Producttype producttype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producttype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producttype);
        }

        // GET: Producttype/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producttype = await _context.Producttype.FindAsync(id);
            if (producttype == null)
            {
                return NotFound();
            }
            return View(producttype);
        }

        // POST: Producttype/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductTypeId,Name,Description,ImagePath,IsActive,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy")] Producttype producttype)
        {
            if (id != producttype.ProductTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producttype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducttypeExists(producttype.ProductTypeId))
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
            return View(producttype);
        }

        // GET: Producttype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producttype = await _context.Producttype
                .FirstOrDefaultAsync(m => m.ProductTypeId == id);
            if (producttype == null)
            {
                return NotFound();
            }

            return View(producttype);
        }

        // POST: Producttype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producttype = await _context.Producttype.FindAsync(id);
            _context.Producttype.Remove(producttype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducttypeExists(int id)
        {
            return _context.Producttype.Any(e => e.ProductTypeId == id);
        }
    }
}
