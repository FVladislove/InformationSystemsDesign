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
    public class SpecsController : Controller
    {
        private readonly InformationSystemsDesignContext _context;

        public SpecsController(InformationSystemsDesignContext context)
        {
            _context = context;
        }

        // GET: Specs
        public async Task<IActionResult> Index()
        {
            var informationSystemsDesignContext = _context.Spec.Include(s => s.GLPR_CdKp).Include(s => s.GLPR_CdSb);
            return View(await informationSystemsDesignContext.ToListAsync());
        }

        // GET: Specs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Spec == null)
            {
                return NotFound();
            }

            var spec = await _context.Spec
                .Include(s => s.GLPR_CdKp)
                .Include(s => s.GLPR_CdSb)
                .FirstOrDefaultAsync(m => m.CdSb == id);
            if (spec == null)
            {
                return NotFound();
            }

            return View(spec);
        }

        // GET: Specs/Create
        public IActionResult Create()
        {
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr");
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr");
            return View();
        }

        // POST: Specs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdSb,CdKp,QtyKp")] Spec spec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdKp);
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdSb);
            return View(spec);
        }

        // GET: Specs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Spec == null)
            {
                return NotFound();
            }

            var spec = await _context.Spec.FindAsync(id);
            if (spec == null)
            {
                return NotFound();
            }
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdKp);
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdSb);
            return View(spec);
        }

        // POST: Specs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CdSb,CdKp,QtyKp")] Spec spec)
        {
            if (id != spec.CdSb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecExists(spec.CdSb))
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
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdKp);
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdSb);
            return View(spec);
        }

        // GET: Specs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Spec == null)
            {
                return NotFound();
            }

            var spec = await _context.Spec
                .Include(s => s.GLPR_CdKp)
                .Include(s => s.GLPR_CdSb)
                .FirstOrDefaultAsync(m => m.CdSb == id);
            if (spec == null)
            {
                return NotFound();
            }

            return View(spec);
        }

        // POST: Specs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Spec == null)
            {
                return Problem("Entity set 'InformationSystemsDesignContext.Spec'  is null.");
            }
            var spec = await _context.Spec.FindAsync(id);
            if (spec != null)
            {
                _context.Spec.Remove(spec);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecExists(string id)
        {
          return (_context.Spec?.Any(e => e.CdSb == id)).GetValueOrDefault();
        }
    }
}
