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
    public class GLPRsController : Controller
    {
        private readonly InformationSystemsDesignContext _context;

        public GLPRsController(InformationSystemsDesignContext context)
        {
            _context = context;
        }

        // GET: GLPRs
        public async Task<IActionResult> Index()
        {
            var informationSystemsDesignContext = _context.GLPR.Include(g => g.TypePr);
            return View(await informationSystemsDesignContext.ToListAsync());
        }

        // GET: GLPRs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GLPR == null)
            {
                return NotFound();
            }

            var gLPR = await _context.GLPR
                .Include(g => g.TypePr)
                .FirstOrDefaultAsync(m => m.CdPr == id);
            if (gLPR == null)
            {
                return NotFound();
            }

            return View(gLPR);
        }

        // GET: GLPRs/Create
        public IActionResult Create()
        {
            ViewData["CdTp"] = new SelectList(_context.TypePr, "CdTp", "NmTp");
            return View();
        }

        // POST: GLPRs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdPr,NmPr,CdTp")] GLPR gLPR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gLPR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CdTp"] = new SelectList(_context.TypePr, "CdTp", "NmTp", gLPR.CdTp);
            return View(gLPR);
        }

        // GET: GLPRs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GLPR == null)
            {
                return NotFound();
            }

            var gLPR = await _context.GLPR.FindAsync(id);
            if (gLPR == null)
            {
                return NotFound();
            }
            ViewData["CdTp"] = new SelectList(_context.TypePr, "CdTp", "NmTp", gLPR.CdTp);
            return View(gLPR);
        }

        // POST: GLPRs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CdPr,NmPr,CdTp")] GLPR gLPR)
        {
            if (id != gLPR.CdPr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gLPR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GLPRExists(gLPR.CdPr))
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
            ViewData["CdTp"] = new SelectList(_context.TypePr, "CdTp", "NmTp", gLPR.CdTp);
            return View(gLPR);
        }

        // GET: GLPRs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GLPR == null)
            {
                return NotFound();
            }

            var gLPR = await _context.GLPR
                .Include(g => g.TypePr)
                .FirstOrDefaultAsync(m => m.CdPr == id);
            if (gLPR == null)
            {
                return NotFound();
            }

            return View(gLPR);
        }

        // POST: GLPRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GLPR == null)
            {
                return Problem("Entity set 'InformationSystemsDesignContext.GLPR'  is null.");
            }
            var gLPR = await _context.GLPR.FindAsync(id);
            if (gLPR != null)
            {
                _context.GLPR.Remove(gLPR);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GLPRExists(string id)
        {
          return (_context.GLPR?.Any(e => e.CdPr == id)).GetValueOrDefault();
        }
    }
}
