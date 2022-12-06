using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InformationSystemsDesign.Data;
using InformationSystemsDesign.Models;

namespace InformationSystemsDesign.Controllers
{
    public class TypePrsController : Controller
    {
        private readonly InformationSystemsDesignContext _context;

        public TypePrsController(InformationSystemsDesignContext context)
        {
            _context = context;
        }

        // GET: TypePrs
        public async Task<IActionResult> Index()
        {
              return _context.TypePr != null ? 
                          View(await _context.TypePr.ToListAsync()) :
                          Problem("Entity set 'InformationSystemsDesignContext.TypePr'  is null.");
        }

        // GET: TypePrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypePr == null)
            {
                return NotFound();
            }

            var typePr = await _context.TypePr
                .FirstOrDefaultAsync(m => m.CdTp == id);
            if (typePr == null)
            {
                return NotFound();
            }

            return View(typePr);
        }

        // GET: TypePrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypePrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdTp,NmTp")] TypePr typePr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typePr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typePr);
        }

        // GET: TypePrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypePr == null)
            {
                return NotFound();
            }

            var typePr = await _context.TypePr.FindAsync(id);
            if (typePr == null)
            {
                return NotFound();
            }
            return View(typePr);
        }

        // POST: TypePrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CdTp,NmTp")] TypePr typePr)
        {
            if (id != typePr.CdTp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typePr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypePrExists(typePr.CdTp))
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
            return View(typePr);
        }

        // GET: TypePrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypePr == null)
            {
                return NotFound();
            }

            var typePr = await _context.TypePr
                .FirstOrDefaultAsync(m => m.CdTp == id);
            if (typePr == null)
            {
                return NotFound();
            }

            return View(typePr);
        }

        // POST: TypePrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypePr == null)
            {
                return Problem("Entity set 'InformationSystemsDesignContext.TypePr'  is null.");
            }
            var typePr = await _context.TypePr.FindAsync(id);
            if (typePr != null)
            {
                _context.TypePr.Remove(typePr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypePrExists(int id)
        {
          return (_context.TypePr?.Any(e => e.CdTp == id)).GetValueOrDefault();
        }
    }
}
